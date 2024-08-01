namespace ExtendedMethods
{
    public static class ExtendSimpleLoggger
    {
        public static void LogError(this ISimpleLoggger logger, string message)
        {
            logger.Log(message, "Error");
        }
    }


}
