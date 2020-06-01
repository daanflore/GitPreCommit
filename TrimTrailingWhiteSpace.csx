public class TrimTrailingWhiteSpace
{
    public static void TrimWhiteSpace(string[] files)
    {
       foreach(string file in files)
       {
           FileInfo fileInfo = new FileInfo(file);
           
           if(fileInfo.Exists)
           {
             TrimFile(fileInfo);
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