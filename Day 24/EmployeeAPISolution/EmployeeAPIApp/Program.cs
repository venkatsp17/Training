using EmployeeAPIApp.Models;
using EmployeeAPIApp.NewFolder;
using EmployeeAPIApp.Repositories;
using EmployeeAPIApp.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RequestTrackerContext>(
              options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            );

            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();

            builder.Services.AddScoped<IEmployeeServices, EmployeeBasicService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
