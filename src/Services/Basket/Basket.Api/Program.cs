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
                var connString = builder.Configuration.GetConnectionString("Database");
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
                    options.Connection(connString!);
                    options.Schema.For<ShoppingCart>().Identity(x => x.UserName); 
                }
                ).UseLightweightSessions();

                builder.Services.AddScoped<IBasketRepository, BasketRepository>();

                builder.Services.AddExceptionHandler<CustomExceptionHandler>();

                builder.Services.AddControllers();
            }


            var app = builder.Build();
            {
                // Configure the HTTP request pipeline.

                app.UseHttpsRedirection();
                app.UseRouting();
                app.MapControllers();


                app.UseExceptionHandler(options => { });

                app.Run();
            }
        }
    }
}
