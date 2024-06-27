namespace BuildingBlocks.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : //InheritsFrom:
                                                           IPipelineBehavior<TRequest, TResponse>
                                                           //With Conditions
                                                           where TRequest : IRequest<TResponse>
                                                           where TResponse : notnull
    {
        //Properties
        #region Non Method Members
        ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
        private enum LogMode
        {
            Start,
            End
        }
        #endregion


        //CTOR Part
        #region CTOR
        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        #endregion

       

        //Actual Handle Logic
        public async Task<TResponse> Handle(TRequest request,
                                            RequestHandlerDelegate<TResponse> next,
                                            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var responseName = typeof(TResponse).Name;


            LogInfo(requestName, responseName, request, LogMode.Start);

            var start = DateTime.UtcNow;

            var response = await next();

            var end = DateTime.UtcNow;

            LogPerformance(start,end,requestName);

            LogInfo(requestName, responseName, request, LogMode.End);

            return response;
        }

        private void LogPerformance(DateTime start, DateTime end,string requestName)
        {
            var timeTaken = end.Subtract(start);

            if (timeTaken.Seconds > 3)
            {
                var messagee = $"[PERFORMANCE] \n====> \nThe Request {requestName} took {timeTaken} seconds. \n<====\n";

                _logger.LogInformation(messagee);
            }
        }
        private void LogInfo(string requestName, string responseName, TRequest request, LogMode mode) 
        {
            var message = string.Empty;

            if (mode == LogMode.Start){
                
                message = $"[START]  Handle \n" +
                          $"====> \n" +
                          $"Request = {requestName} , \n" +
                          $"Response = {responseName} , \n" +
                          $"RequestData = {request}. \n" +
                          $"====> \n" ;
            }
            if (mode == LogMode.End)
            {
                message = $"[END]  Handled \n====> \n{requestName} with {responseName}. \n<====\n";
            }

            _logger.LogInformation(message);
        }

    }
}
