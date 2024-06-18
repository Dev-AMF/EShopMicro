using Catalog.Api.UseCases.Products.IValidators;

namespace Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                // Add services to the container.

                builder.Services.AddControllers();

                builder.Services.AddMediatR(config =>
                {
                    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
                });

                builder.Services.AddValidatorsFromAssembly((typeof(Program).Assembly));

                builder.Services.AddMarten(options =>
                {
                    options.Connection(builder.Configuration.GetConnectionString("Database")!);
                })
                    .UseLightweightSessions();


                builder.Services.AddTransient(typeof(ICommandValidator<>), typeof(CommandValidator<>) );

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
