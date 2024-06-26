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
                var connString = builder.Configuration.GetConnectionString("Database");
                //


                builder.Services.AddControllers();

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
                }
                ).UseLightweightSessions();

                if (builder.Environment.IsDevelopment())
                    builder.Services.InitializeMartenWith<CatalogInitialData>();

                builder.Services.AddExceptionHandler<CustomExceptionHandler>();

                builder.Services.AddHealthChecks().AddNpgSql(connString!);

                builder.Services.AddControllers();
            }


            var app = builder.Build();
            {
                // Configure the HTTP request pipeline.


                app.UseHttpsRedirection();
                app.UseRouting();
                app.MapControllers();

                app.UseExceptionHandler(options => { });

            
                app.UseHealthChecks("/api/catalog/health",
                        new HealthCheckOptions
                        {
                            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                        });

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
