namespace QuickStars.MaViCS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.LoadConfiguration(builder.Configuration);

            builder.Services.ConfigureDatabase(builder.Configuration);

            builder.Services.ConfigureIdentity(builder.Configuration);

            builder.Services.ConfigureDependencyInjection();

            builder.Services.ConfigureAuthentication(builder.Configuration);

            builder.Services.ConfigureSwagger(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}