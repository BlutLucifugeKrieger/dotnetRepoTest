using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using azure_test.Data;
namespace azure_test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<azure_testContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("connection") ,

                sqlServerOptionsAction: sqlOptions =>
                {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5, // Número máximo de reintentos
                        maxRetryDelay: TimeSpan.FromSeconds(5), // Tiempo máximo entre reintentos
                        errorNumbersToAdd: null); // Agregar números de errores adicionales si es necesario
                }));


           

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>

                    options.AddPolicy("nuevaPolitica", app =>
                    {

                        app.AllowAnyHeader();
                        app.AllowAnyMethod();
                        app.AllowAnyOrigin();
                    })

                ); ;




            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("nuevaPolitica");

            app.MapControllers();

            app.Run();
        }
    }
}