# load "CommandRunner.csx"

CommandRunner.CommandRunnerResult result = CommandRunner.Execute("git diff-index --check -z HEAD");
Console.WriteLine("Hello world!");
