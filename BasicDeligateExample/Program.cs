// See https://aka.ms/new-console-template for more information

class Program
{
    delegate void LogDel(string text);
    public static void Main(string[] args)
    {
        // Practicing Simgle Delegates
        // //LogDel logDel = new LogDel(LogToTextFile);
        // Console.WriteLine("Please enter your name");
        //
        // var userName = Console.ReadLine();
        //
        // logDel(userName);
        //
        // Console.ReadKey();
        
        //MultiCast Delegates

        Log log = new Log();
        LogDel logToscreen, logTofile;
        logToscreen = new LogDel(log.LogtextToScreen);
        logTofile = new LogDel(log.LogToTextFile);
        LogDel multilog = logTofile + logToscreen;
        
        Console.WriteLine("Please enter your name");
        
        var userName = Console.ReadLine();
        
        multilog(userName);
        
        Console.ReadKey();
    }

    static void LogtextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}:{text}");
    }

    static void LogToTextFile(string text)
    {
        using (StreamWriter writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "text.txt"), true))
        {
            writer.WriteLine($"{DateTime.Now}:{text}");
        }
    }

}

class Log
{
    public void LogtextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}:{text}");
    }

    public void LogToTextFile(string text)
    {
        using (StreamWriter writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "text.txt"), true))
        {
            writer.WriteLine($"{DateTime.Now}:{text}");
        }
    }

}