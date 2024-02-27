using Cars_api.Contexts;
//using Cars_api.Controllers;
using Microsoft.EntityFrameworkCore;
using Cars_api.Controllers;
//using Cars_api.Controllers;

namespace Cars_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Inject the ShoppinglistAppContext into the dependency injection container
            builder.Services.AddDbContext<CarsContext>(options =>
            {
                options.UseSqlServer("Server=ASG-DB-01;Initial Catalog=Cars;Persist Security Info=False;User ID=sa;Password=Temp1234!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            });

            


            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

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

            app.UseCors(cors=>cors.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseAuthorization();


            app.MapControllers();

                        app.MapCarStatEndpoints();

            

                //      app.MapCarStatEndpoints();

            app.Run();
        }
    }
}
