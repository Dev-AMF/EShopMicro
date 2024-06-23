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

                builder.Services.AddExceptionHandler<CustomExceptionHandler>();
            }

            var app = builder.Build();
            {
                // Configure the HTTP request pipeline.

                app.UseHttpsRedirection();
                app.MapControllers();

                app.UseExceptionHandler(options => { });

                #region OldExceptionHandler
                //app.UseExceptionHandler(exceptionHandlerApp =>
                //{
                //    exceptionHandlerApp.Run(async context =>
                //    {
                //        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                //        if (exception == null)
                //        {
                //            return;
                //        }
                //        var problemDetails = new ProblemDetails
                //        {

                //            Title = exception.Message,
                //            Status = StatusCodes.Status500InternalServerError,
                //            Detail = exception.StackTrace

                //        };

                //        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                //        logger.LogError(exception, exception.Message);

                //        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                //        context.Response.ContentType = "application/problem+json";

                //        await context.Response.WriteAsJsonAsync(problemDetails);

                //    });
                //});
                #endregion

                app.Run();
            }


        }
    }
}
