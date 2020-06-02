# load "CommandRunner.csx"
# load "GitDiffIndexParser.csx"
# load "TrimTrailingWhiteSpace.csx"
# load "GitStasher.csx"

//https://github.com/imoldman/config/blob/master/pre-commit.git.sh
//https://medium.com/@max.hamulyak/using-c-code-in-your-git-hooks-66e507c01a0f
//

GitStasher.StashChanges();

try
{
    CommandRunner.CommandRunnerResult result = CommandRunner.Execute("git diff-index --check -z HEAD");

    if( result.ExitCode == 2)
    {
        string[] files = GitDiffIndexParser.GetLinesWithWhiteSpace(result.Output);
        TrimTrailingWhiteSpace.TrimWhiteSpace(files);
        result = CommandRunner.Execute("git status -s");
    }
}
catch(Exception ex)
{
      Console.Error.WriteLine(ex);
}
finally
{
    GitStasher.UnstashChanges();
}