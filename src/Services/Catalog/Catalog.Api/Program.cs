using BuildingBlocks.Behaviours;

namespace Catalog.Api
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
                //


                builder.Services.AddControllers();

                builder.Services.AddMediatR(config =>
                {
                    config.RegisterServicesFromAssembly(assembly);
                    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                });

                builder.Services.AddValidatorsFromAssembly(assembly);

                builder.Services.AddMarten(options =>
                {
                    options.Connection(builder.Configuration.GetConnectionString("Database")!);
                })
                    .UseLightweightSessions();
               

            }

            var app = builder.Build();
            {
                // Configure the HTTP request pipeline.

                app.UseHttpsRedirection();
                app.MapControllers();

                app.Run();
            }


        }
    }
}
