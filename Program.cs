using Microsoft.EntityFrameworkCore;
using ZooManagement.Repositories;

namespace ZooManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddTransient<IAnimalsRepo, AnimalsRepo>();
            builder.Services.AddTransient<IAnimalTypesRepo, AnimalTypesRepo>();
            
            builder.Services.AddDbContext<ZooManagementDbContext>(options =>
            {
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
                options.UseSqlite("Data Source=zoomanagement.db");
            });
            
            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ZooManagementDbContext>();
            context.Database.EnsureCreated();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

    //         var summaries = new[]
    //         {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    //         app.MapGet("/weatherforecast", () =>
    //         {
    //             var forecast = Enumerable.Range(1, 5).Select(index =>
    //                 new WeatherForecast
    //                 (
    //                     DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //                     Random.Shared.Next(-20, 55),
    //                     summaries[Random.Shared.Next(summaries.Length)]
    //                 ))
    //                 .ToArray();
    //             return forecast;
    //         })
    //         .WithName("GetWeatherForecast")
    //         .WithOpenApi();

            app.Run();



        }

    }
}

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }