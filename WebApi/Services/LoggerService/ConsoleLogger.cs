namespace WebApi.Services.LoggerService
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            System.Diagnostics.Debug.WriteLine("[ConsoleLogger] | " + message);
        }
    }
}
