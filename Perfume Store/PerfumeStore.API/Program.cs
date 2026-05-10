
using PerfumeStore.API.Extensions;
using PerfumeStore.API.Middleware;
using PerfumeStore.Application;
using PerfumeStore.Infrastructure;
using Serilog;

namespace PerfumeStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.AddSerilog();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddDatabase(builder.Configuration);
            builder.Services.AddIdentityServices();
            builder.Services.AddJwtAuthentication(builder.Configuration);
            builder.Services.AddCaching(builder.Configuration);
            builder.Services.AddSwagger();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            else
            {
                app.UseMiddleware<ExceptionHandlingMiddleware>();
            }

            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
