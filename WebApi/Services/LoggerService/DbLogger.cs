namespace WebApi.Services.LoggerService
{
    public class DbLogger : ILoggerService
    {
        public void Write(string message)
        {
            System.Diagnostics.Debug.WriteLine("[DbLogger] | " + message);
        }
    }
}
