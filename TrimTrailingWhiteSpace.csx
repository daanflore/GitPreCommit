#load "GitStager.csx"
#load "CommandRunner.csx"

public static class TrimTrailingWhiteSpace
{
    public static void TrimWhiteSpace(string[] files)
    {
       Logger.WriteLine("Looping through files");
       foreach(string file in files)
       {
           FileInfo fileInfo = new FileInfo(file);

           if(fileInfo.Exists)
           {
                Logger.WriteLine("Making backup");
                string[] fileContent = File.ReadAllLines(fileInfo.FullName);
                Logger.WriteLine("Getting latest from index");
                CommandRunner.CommandRunnerResult result = CommandRunner.Execute($"git checkout -- \"{fileInfo.FullName}\"");
                Logger.WriteLine("Trim index file");
                TrimFile(fileInfo);
                Logger.WriteLine("Stage changes to file");
                GitStager.StageChanges(fileInfo.FullName);
                Task.Delay(100).Wait();
                Logger.WriteLine("Revert to file not on index and remove spaces");
                TrimLine(fileInfo, fileContent);
           }
       }
    }

    public static void TrimFile(FileInfo file)
    {
        string[] allLines = File.ReadAllLines(file.FullName);
        TrimLine(file, allLines);
    }

    public static void TrimLine(FileInfo file, string[] lines)
    {
        using (StreamWriter sw = new StreamWriter(file.FullName))
        {
            foreach (string line in lines)
            {
                if(line != null)
                {
                    string trimmedLine = line.TrimEnd(' ');
                    sw.WriteLine(trimmedLine);
                    Logger.WriteLine($"Content: {trimmedLine}");
                }
            }
        }
    }
}
