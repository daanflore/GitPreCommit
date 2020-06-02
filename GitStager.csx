#load "CommandRunner.csx"

public static class GitStager
{
    public static void StageChanges(string file)
    {
       CommandRunner.CommandRunnerResult result = CommandRunner.Execute($"git add {file}");

        using (StreamWriter sw = new StreamWriter(@"c:\temp\log.txt"))
        {
            sw.WriteLine($"Status: {result.ExitCode}");
            sw.WriteLine($"Error: {result.Error}");
            sw.WriteLine($"Output: {result.Output}");
        }
    }
}
