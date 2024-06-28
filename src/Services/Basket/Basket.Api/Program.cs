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

                builder.Services.AddControllers();
            }


            var app = builder.Build();
            {
                // Configure the HTTP request pipeline.

                app.UseHttpsRedirection();
                app.UseRouting();
                app.MapControllers();


                app.Run();
            }
        }
    }
}
