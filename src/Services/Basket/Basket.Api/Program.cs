using HealthChecks.UI.Client;

namespace Basket.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                // Add services to the container.

                //Variebles
                var assembly = typeof(Program).Assembly;
                var connStringForPG = builder.Configuration.GetConnectionString("Database");
                var connStringForRedis = builder.Configuration.GetConnectionString("Redis");
                //

                builder.Services.AddMediatR(config =>
                {
                    config.RegisterServicesFromAssembly(assembly);
                    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
                });

                builder.Services.AddValidatorsFromAssembly(assembly);

                builder.Services.AddMarten(options =>
                {
                    options.Connection(connStringForPG!);
                    options.Schema.For<ShoppingCart>().Identity(x => x.UserName); 
                }
                ).UseLightweightSessions();

                builder.Services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = connStringForRedis;
                });

                builder.Services.AddScoped<IBasketRepository, BasketRepository>();

                //builder.Services.AddScoped<IBasketRepository>(provider =>
                //{
                //    var basketRepository = provider.GetRequiredService<BasketRepository>();
                //    var distributedCache = provider.GetRequiredService<IDistributedCache>();

                //    return new ChachedBasketRepository(basketRepository, distributedCache);
                //});
                //===> Manually Registering Chached Implementation of BaskertRepository,
                //As its Default Implementation With Providing Chached's Own Dependencies. <===

                builder.Services.Decorate<IBasketRepository, ChachedBasketRepository>();


                builder.Services.AddExceptionHandler<CustomExceptionHandler>();

                builder.Services.AddHealthChecks()
                    .AddNpgSql(connStringForPG!)
                    .AddRedis(connStringForRedis!);

                builder.Services.AddControllers();
            }


            var app = builder.Build();
            {
                // Configure the HTTP request pipeline.

                app.UseHttpsRedirection();
                app.UseRouting();
                app.MapControllers();


                app.UseExceptionHandler(options => { });

                app.UseHealthChecks("/api/basket/health",
                    new HealthCheckOptions
                    {
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                    });

                app.Run();
            }
        }
    }
}
