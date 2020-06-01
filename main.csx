# load "CommandRunner.csx"
# load "GitDiffIndexParser.csx"
# load "TrimTrailingWhiteSpace.csx"

CommandRunner.CommandRunnerResult result = CommandRunner.Execute("git diff-index --check -z HEAD");

if( result.ExitCode == 2)
{
    string[] files = GitDiffIndexParser.GetLinesWithWhiteSpace(result.Output);
    TrimTrailingWhiteSpace.TrimWhiteSpace(files);    
}

Console.WriteLine("Hello world!");
