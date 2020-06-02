public static class Logger
{
    public static string FullFileName
    {
        get;
        set;
    }

    public static bool Log
    {
        get;
        set;
    } = true;

    private static string logFormat = "{0} - {1}";

    public static void Start()
    {
       if(Log)
       {
           File.AppendAllText(FullFileName, new String('-', 50) + Environment.NewLine);
       }
    }

    public static void WriteLine(String message)
    {
        if(Log)
        {
            File.AppendAllText(FullFileName, string.Format(logFormat, DateTime.Now, message + Environment.NewLine));
        }
    }

    public static void End()
    {
        if(Log)
        {
            File.AppendAllText(FullFileName, new String('-', 50) + Environment.NewLine);
        }
    }
}