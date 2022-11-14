using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuickStars.MaViCS.Business.Interfaces;
using QuickStars.MaViCS.Business.Services;
using QuickStars.MaViCS.Domain.Auth;
using QuickStars.MaViCS.Domain.Data;
using QuickStars.MaViCS.Domain.Data.Interceptors;
using QuickStars.MaViCS.Domain.Interfaces;
using QuickStars.MaViCS.Domain.Repositories;
using System.Text;

namespace QuickStars.MaViCS.Extensions
{
    public static class ServiceExtensions
    {

        public static void LoadConfiguration(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            var identitySection = configurationManager.GetSection("Identity");
            services.Configure<IdentitySettings>(identitySection);
        }

        public static void ConfigureDatabase(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            // add interceptors into DI
            services.AddSingleton<SaveInterceptor>();

            // configure DatabaseContext with serviceProvider and optionBuilder
            services.AddDbContext<DatabaseContext>((provider, options) =>
            {
                options.AddInterceptors(provider.GetRequiredService<SaveInterceptor>());
                options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            var identitySettings = configurationManager.GetSection("Identity").Get<IdentitySettings>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identitySettings.Secret)),

                    ValidateIssuer = true,
                    ValidIssuer = identitySettings.Issuer,

                    ValidateAudience = true,
                    ValidAudience = identitySettings.Audience,

                    ValidateLifetime = true, //validate the expiration and not before values in the token

                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

        }

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            // add repositories
            services.AddScoped<ITalentRepository, TalentRepository>();
            services.AddScoped<IShowRepository, ShowRepository>();

            // add services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ITalentService, TalentService>();
            services.AddScoped<IShowService, ShowService>();

            services.AddControllers();
        }

        public static void ConfigureSwagger(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddEndpointsApiExplorer();

            //configuration de Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MaViCS.API", Version = "v1" });

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
