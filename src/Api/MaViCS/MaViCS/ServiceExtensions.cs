using MaViCS.Business.Interfaces;
using MaViCS.Business.Services;
using MaViCS.Domain.Framework;
using MaViCS.Domain.Framework.Authentication;
using MaViCS.Domain.Framework.Configuration;
using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Persistance;
using MaViCS.Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace MaViCS
{
    public static class ServiceExtensions
    {

        public static void LoadConfiguration(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            var authSection = configurationManager.GetSection("AuthSettings");
            services.Configure<AuthSettings>(authSection);
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
            services.AddSingleton<AuthHelper>();

            services.AddControllers();

            // add services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITalentService, TalentService>();
            services.AddScoped<ITownService, TownService>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IShowService, ShowService>();

            // add repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITalentRepository, TalentRepository>();
            services.AddScoped<ITownRepository, TownRepository>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IShowRepository, ShowRepository>();

        }

        public static void ConfigureAuthentication(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            var authConfig = configurationManager.GetSection("AuthSettings").Get<AuthSettings>();

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
                    ValidIssuer = authConfig.TokenSettings.Issuer,
                    ValidAudience = authConfig.TokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfig.TokenSettings.Secret)),
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
