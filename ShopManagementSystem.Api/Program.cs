using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using ShopManagementSystem.Application.Interfaces.Repositories;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Application.Services;
using ShopManagementSystem.Domain.Entities.User;
using ShopManagementSystem.Infrastructure.Data.Context;
using ShopManagementSystem.Infrastructure.Repositories;
using System.Text;

namespace ShopManagementSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddRazorPages();

            #region Swagger

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT Token"
                });

                options.AddSecurityRequirement(document =>
                    new OpenApiSecurityRequirement
                    {
                        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
                    });
            });

            #endregion

            #region DB Context
            builder.Services.AddDbContext<ProgramContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                );
            });
            #endregion

            #region IoC

            builder.Services.AddScoped<PasswordHasher<User>>();

            #region Services

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            #endregion

            #region Repository

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            #endregion

            #endregion

            #region Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
            #endregion

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapRazorPages();

            app.Run();
        }
    }
}
