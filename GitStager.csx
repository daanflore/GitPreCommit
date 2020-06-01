#load "CommandRunner.csx"

public static class GitStager
{
    public static void StageChanges(string file)
    {
        CommandRunner.Execute($"git add {file}");
    }
}
