using MaViCS.Business.Interfaces;
using MaViCS.Business.Services;
using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Persistance;
using MaViCS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MaViCS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("MaViCS");
                //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<ITalentService, TalentService>();
            builder.Services.AddScoped<ITownService, TownService>();
            builder.Services.AddScoped<ITourService, TourService>();

            builder.Services.AddScoped<ITalentRepository, TalentRepository>();
            builder.Services.AddScoped<ITownRepository, TownRepository>();
            builder.Services.AddScoped<ITourRepository, TourRepository>();
            builder.Services.AddScoped<IShowRepository, ShowRepository>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}