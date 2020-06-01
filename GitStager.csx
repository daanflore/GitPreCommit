#load "CommandRunner.csx"

public static class GitStasher
{
    public static void StageChanges(string file) 
    {
        CommandRunner.Execute($"git add {file}");
    }
}