namespace IZCommerce.Logging.Interfaces
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string mesasge);
        void LogError(string message);
    }
}
