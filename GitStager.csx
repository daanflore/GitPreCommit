#load "CommandRunner.csx"
#load "Logger.csx"
public static class GitStager
{
    public static void StageChanges(string file)
    {
        CommandRunner.CommandRunnerResult result = CommandRunner.Execute($"git add {file}");
        Logger.WriteLine($"ExitCode: {result.ExitCode}");
        Logger.WriteLine($"Error: {result.Error}");
        Logger.WriteLine($"Output: {result.Output}");
    }
}
