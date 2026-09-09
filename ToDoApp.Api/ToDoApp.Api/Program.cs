using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Context;
using ToDoApp.Services.Interfaces;
using ToDoApp.Services.Services;
using ToDoApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi;


namespace ToDoApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<ToDoAppContext>();

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "Bearer"
                });

                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference("Bearer", document)] = []
                }); 
            });

            // Add authentication and authorization services.
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<ToDoAppContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0))));

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICurrentUserService, CurentUserService>();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ICategoriesService, CategoriesService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapIdentityApi<User>();

            app.MapControllers();

            app.Run();
        }
    }
}
