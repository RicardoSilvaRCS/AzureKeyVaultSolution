
using AzureDataAccess;
using DataAccessInterfaces;
using DatabaseAccess;
using DatabaseAccess.Data;
using DatabaseAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using RedisDataAccess;
using Services;
using ServicesInterfaces;

namespace BigKeyVault {
    public class Program {
        public static void Main (string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ICacheManagementServices, RedisManagementServices>();
            builder.Services.AddSingleton<ICacheDataAccess, RedisPersistence>();
            builder.Services.AddSingleton<ISimpleSecretDataAccess, AzureKeyvaultPersistence>();
            builder.Services.AddSingleton<ISimpleSecretService, Services.AzureKeyvaultServices>();


            builder.Services.AddDbContext<AppDbContext>(options =>
                                         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
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
