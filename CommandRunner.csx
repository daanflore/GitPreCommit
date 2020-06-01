public static class CommandRunner
{
    public static CommandRunnerResult Execute(string command)
    {
        // according to: https://stackoverflow.com/a/15262019/637142
        // thans to this we will pass everything as one command
        command = command.Replace("\"", "\"\"");
        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c \"" + command + "\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                RedirectStandardError = true
            }
        };

        proc.Start();
        proc.WaitForExit();

        CommandRunnerResult commandRunnerResult = new CommandRunnerResult()
        {
            ExitCode = proc.ExitCode,
            Output = proc.StandardOutput.ReadToEnd(),
            Error  = proc.StandardError.ReadToEnd()
        };

        return commandRunnerResult;
    }

    public class CommandRunnerResult
    {
        public int ExitCode
        {
            get;
            set;
        }

        public string Error
        {
            get;
            set;
        }

        public string Output
        {
            get;
            set;
        }
    }
}
