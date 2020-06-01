public class CommandRunner {
 public static string Execute(string command) {
  // according to: https://stackoverflow.com/a/15262019/637142
  // thans to this we will pass everything as one command
  command = command.Replace("\"", "\"\"");
  var proc = new Process {
   StartInfo = new ProcessStartInfo {
    FileName = "cmd",
     Arguments = "-c \"" + command + "\"",
     UseShellExecute = false,
     RedirectStandardOutput = true,
     CreateNoWindow = true
   }
  };
  
  proc.Start();
  proc.WaitForExit();
  
  if (proc.ExitCode != 0 || proc.ExitCode != 2) {
   return proc.ExitCode.ToString();
  }
  
  return proc.StandardOutput.ReadToEnd();
 }
}