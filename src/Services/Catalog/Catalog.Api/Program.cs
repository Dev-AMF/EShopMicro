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
