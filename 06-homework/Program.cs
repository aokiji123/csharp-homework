class CountFiles
{
    static void Main()
    {
        static int FilesCounting(string path)
        {
            int count = 0;
            string[] files = Directory.GetFiles(path);
            count += files.Length;

            string[] subfiles = Directory.GetDirectories(path);
            foreach (string subfile in subfiles)
            {
                count += FilesCounting(subfile);
            }

            return count;
        }

        string path = "/Users/mac/Desktop";
        int fileCount = FilesCounting(path);

        Console.WriteLine(fileCount);
    }
}
