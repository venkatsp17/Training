using Azure.Identity;
using KeyVaultTest.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KeyVaultTest
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

            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables();

            var keyVaultUri = $"https://{builder.Configuration["KeyVault:Vault"]}.vault.azure.net/";

            // Use the default secret manager
            builder.Configuration.AddAzureKeyVault(keyVaultUri);

            var connectionString = builder.Configuration["conString"];
            #region contexts
            builder.Services.AddDbContext<TempDB>(
             options => options.UseSqlServer(connectionString)
             );
            #endregion


            var app = builder.Build();

           
            Console.WriteLine($"Connection String: {connectionString}");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
