using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuickStars.MaViCS.Business.Interfaces;
using QuickStars.MaViCS.Business.Services;
using QuickStars.MaViCS.Domain.Data;
using QuickStars.MaViCS.Domain.Interfaces;
using QuickStars.MaViCS.Domain.Repositories;
using QuickStars.MaViCS.Domain.Security;
using QuickStars.MaViCS.Domain.Security.Configuration;
using System.Text;

namespace QuickStars.MaViCS
{
    public static class ServiceExtensions
    {

        public static void LoadConfiguration(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            var securitySection = configurationManager.GetSection("SecuritySettings");
            services.Configure<SecuritySettings>(securitySection);
        }

        public static void ConfigureDatabase(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
            });
        }

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<ISecurityService, SecurityService>();

            // add repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITalentRepository, TalentRepository>();
            services.AddScoped<IShowRepository, ShowRepository>();

            // add services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITalentService, TalentService>();
            services.AddScoped<IShowService, ShowService>();

            services.AddControllers();

        }

        public static void ConfigureAuthentication(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            var securitySettings = configurationManager.GetSection("SecuritySettings").Get<SecuritySettings>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = securitySettings.JWT.Issuer,
                    ValidAudience = securitySettings.JWT.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitySettings.JWT.Secret)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddEndpointsApiExplorer();

            //configuration de Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Padoru.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Ajouter le token ainsi : \"Bearer xxxx\" où xxxx est votre token d'authentification",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

    }
}
