using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuickStars.MaViCS.Domain.Auth;
using QuickStars.MaViCS.Domain.Data;
using System.Text;

namespace QuickStars.MaViCS
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
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {

            // add repositories

            // add services

            services.AddControllers();

        }

        public static void ConfigureAuthentication(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            var identitySettings = configurationManager.GetSection("Identity").Get<IdentitySettings>();

            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = identitySettings.Audience,
                    ValidIssuer = identitySettings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identitySettings.Secret))
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
