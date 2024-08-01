namespace ExtendedMethods
{
    public interface ISimpleLoggger
    {
        void Log(string message);
        void Log(string message, string messageType);
    }
}