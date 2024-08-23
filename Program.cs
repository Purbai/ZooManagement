using Microsoft.EntityFrameworkCore;
using ZooManagement.Repositories;
using ZooManagement.Data;

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

            if (!context.Animals.Any())
            {
                var animal = SampleAnimals.GetAnimals();
                context.Animals.AddRange(animal);
                context.SaveChanges();
            }
            if (!context.AnimalTypes.Any())
            {
                var animalTypes = SampleAnimalType.GetAnimalTypes();
                context.AnimalTypes.AddRange(animalTypes);
                context.SaveChanges();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
