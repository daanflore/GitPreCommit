# load "CommandRunner.csx"
# load "GitDiffIndexParser.csx"
# load "TrimTrailingWhiteSpace.csx"
# load "GitStashRunner.csx"

GitStashRunner.StashChanges();
CommandRunner.CommandRunnerResult result = CommandRunner.Execute("git diff-index --check -z HEAD");

if( result.ExitCode == 2)
{
    string[] files = GitDiffIndexParser.GetLinesWithWhiteSpace(result.Output);
    TrimTrailingWhiteSpace.TrimWhiteSpace(files);    
}     

GitStashRunner.UnstashChanges(); 
Console.WriteLine("Hello world!");   
