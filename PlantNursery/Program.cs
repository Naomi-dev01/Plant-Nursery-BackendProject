
using Microsoft.EntityFrameworkCore;
using PlantNursery.API.Mapping;
using PlantNursery.BLL.Interfaces;
using PlantNursery.BLL.Services;
using PlantNursery.DAL.Context;
using PlantNursery.DAL.Interfaces;
using PlantNursery.DAL.Repositories;

namespace PlantNursery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:3000") // הכתובת של הפרונט
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();


            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile<ApiMappingProfile>();
                //If several profiles
            });

            // builder.Services.AddAutoMapper(typeof(ApiMappingProfile));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IOrder, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddDbContext<PlantNurseryDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowFrontend");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
