
using HRLeaveManagementApplication;
using HRLeaveManagementInfrastructure;
using HRLeaveManagementPersistence;

namespace HRLeaveManagementApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(builder.Configuration);
            builder.Services.ConfigurePersistenceServices(builder.Configuration);
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();
            app.UseCors("CorsPolicy");

            app.Run();
        }
    }
}
