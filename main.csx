# load "CommandRunner.csx"
# load "GitDiffIndexParser.csx"
# load "TrimTrailingWhiteSpace.csx"
# load "GitStasher.csx"
# load "logger.csx"

//https://github.com/imoldman/config/blob/master/pre-commit.git.sh
//https://medium.com/@max.hamulyak/using-c-code-in-your-git-hooks-66e507c01a0f
//
Logger.FullFileName = @"c:\temp\pre-commit.log";
Logger.Start();
Logger.WriteLine("Stashing changes");
GitStasher.StashChanges();

try
{
    Logger.WriteLine("Get files with line ending problems");
    CommandRunner.CommandRunnerResult result = CommandRunner.Execute("git diff-index --check -z HEAD");

    if( result.ExitCode == 2)
    {
        Logger.WriteLine("Problems found, getting files");
        string[] files = GitDiffIndexParser.GetLinesWithWhiteSpace(result.Output);
        Logger.WriteLine("Trim spaces from line endings");
        TrimTrailingWhiteSpace.TrimWhiteSpace(files);
        Logger.WriteLine("Check git status");
        result = CommandRunner.Execute("git status -s");
    }
}
catch(Exception ex)
{
    Logger.WriteLine("Error: " + ex.ToString());
    Console.Error.WriteLine(ex);
}
finally
{
    Logger.WriteLine("Unstashing changes");
    GitStasher.UnstashChanges();
    Logger.End();
}
