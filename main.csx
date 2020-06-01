# load "CommandRunner.csx"
# load "GitDiffIndexParser.csx"
# load "TrimTrailingWhiteSpace.csx"
# load "GitStasher.csx"

GitStasher.StashChanges();

try
{
    CommandRunner.CommandRunnerResult result = CommandRunner.Execute("git diff-index --check -z HEAD");

    if( result.ExitCode == 2)
    {
        string[] files = GitDiffIndexParser.GetLinesWithWhiteSpace(result.Output);
        TrimTrailingWhiteSpace.TrimWhiteSpace(files);
    }
}
finally
{
    GitStasher.UnstashChanges();
}

Console.WriteLine("Hello world!");
