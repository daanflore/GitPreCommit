public static class Logger
{
    public static string FullFileName
    {
        get;
        set;
    }

    public static void WriteLine(String message)
    {
        File.AppendAllText(FullFileName, message + Environment.NewLine);
    }
}