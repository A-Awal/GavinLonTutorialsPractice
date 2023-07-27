using System.Diagnostics;

namespace LoggingComponent;

public class Logging
{
    //[Conditional("LOG_INFO")]
    [Obsolete("The LogToScreen method has now been deprecated. Please use the LogToFile method instead", true)]
   public static void LogToScreen(string msg)
    {
        Console.WriteLine(msg);
    }
   public static void LogToFile(string msg)
    {
        Console.WriteLine("I have logged to screen" + msg);
    }
}