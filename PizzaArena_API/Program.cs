
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.ChefSpecialFolder;
using PizzaArena_API.Services.ChefSpecialFolder.IChefService;
using PizzaArena_API.Services.GlobalSettingsFolder;
using PizzaArena_API.Services.GlobalSettingsFolder.IGlobalService;
using PizzaArena_API.Services.OrderFolder;
using PizzaArena_API.Services.OrderFolder.IOrderService;
using PizzaArena_API.Services.ProductFolder;
using PizzaArena_API.Services.ProductFolder.IProductService;
using PizzaArena_API.Services.RestaurantsFolder;
using PizzaArena_API.Services.RestaurantsFolder.IRestaurantsService;
using PizzaArena_API.Services.UserFolder;
using PizzaArena_API.Services.UserFolder.IUserService;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;

namespace PizzaArena_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PizzArenaDbContext>();
            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
            builder.Services.AddScoped<IChefSepcial, ChefSpecialService>();
            builder.Services.AddScoped<IGlobalSettings, GlobalSettingsService>();
            builder.Services.AddScoped<IRestaurants, RestaurantService>();
            builder.Services.AddScoped<IOrder, OrderService>();
            builder.Services.AddScoped<IProduct, ProductService>();

            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<PizzArenaDbContext>().AddDefaultTokenProviders();

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("AuthSettings:JwtOptions"));

            var settingsSection = builder.Configuration.GetSection("AuthSettings:JwtOptions");
            var secret = settingsSection.GetValue<string>("Secret");
            var issuer = settingsSection.GetValue<string>("Issuer");
            var audience = settingsSection.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secret);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateAudience = true,
                    NameClaimType = "sub"
                };
            });

            

            // Add services to the container.

            builder.Services.AddControllers();
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

            app.UseAuthentication();

            app.UseAuthorization();

            


            app.MapControllers();

            app.Run();
        }
    }
}
