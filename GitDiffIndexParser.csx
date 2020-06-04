public static class GitDiffIndexParser
{


    public static string[] GetLinesWithWhiteSpace(string gitResult)
    {
        HashSet<string> filesWithWhiteSpace = new HashSet<string>();
        Logger.WriteLine("splitting git result: " + gitResult);
        string[] lines = gitResult.Split("\n");

        Logger.WriteLine("Searching file names and adding to list to check");
        for (int index = 0; index < lines.Length; index++)
        {
            string line = lines[index];

            if(CheckValidLine(line))
            {
                line = ParseFileName(line);

                if(!filesWithWhiteSpace.Contains(line))
                {
                    filesWithWhiteSpace.Add(line);
                }
            }
        }

        Logger.WriteLine($"Returning {filesWithWhiteSpace.Count} results");
        return filesWithWhiteSpace.ToArray();
    }

    private static string ParseFileName(string lineToParse)
    {
        return lineToParse.Split(':')[0];
    }

    private static bool CheckValidLine(string line)
    {
        return !string.IsNullOrWhiteSpace(line) && !line.StartsWith('+') && !line.StartsWith('-');
    }
}
