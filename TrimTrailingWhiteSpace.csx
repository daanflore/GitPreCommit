#load "GitStager.csx"
#load "CommandRunner.csx"

public static class TrimTrailingWhiteSpace
{
    public static void TrimWhiteSpace(string[] files)
    {
       foreach(string file in files)
       {
           FileInfo fileInfo = new FileInfo(file);

           if(fileInfo.Exists)
           {
                string fileContent = File.ReadAllText(fileInfo.FullName);
                CommandRunner.CommandRunnerResult result = CommandRunner.Execute($"git checkout -- \"{fileInfo.FullName}\"");
                TrimFile(fileInfo);
                GitStager.StageChanges(fileInfo.FullName);
                File.WriteAllText(fileInfo.FullName, fileContent);
           }
       }
    }

    public static void TrimFile(FileInfo file)
    {
        string[] allLines = File.ReadAllLines(file.FullName);

        using (StreamWriter sw = new StreamWriter(file.FullName))
        {
            foreach (string line in allLines)
            {
                if(line != null)
                {
                    sw.WriteLine(line.TrimEnd(' '));
                }
            }
        }
    }
}
