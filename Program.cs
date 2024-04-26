
using Backend.Models;
using Backend.Repo.RepoImplementation;
using Backend.Repo.RepoInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend
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
            builder.Services.AddTransient<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddDbContext<EmpContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseMain"));
            });

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("Open4Localhost", crosPolicy =>
                {
                    crosPolicy.WithOrigins("http://localhost:7000", "https://localhost:7001", "https://localhost:7002");
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("Open4Localhost");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
