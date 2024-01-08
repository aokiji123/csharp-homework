class FileExtensionStats
{
    public int FileCount { get; set; }
    public long TotalSize { get; set; }
}

class Program
{
    static void Main()
    {
        var directoryInfo = new DirectoryInfo(@"../../");
        var extensionStatistics = new Dictionary<string, FileExtensionStats>();

        try
        {
            var allFiles = RetrieveAllFiles(directoryInfo, "*");

            foreach (var file in allFiles)
            {
                var extension = file.Extension;
                if (string.IsNullOrEmpty(extension))
                    extension = "NoExtension";

                if (extensionStatistics.ContainsKey(extension))
                {
                    FileExtensionStats stats = extensionStatistics[extension];
                    stats.FileCount++;
                    stats.TotalSize += file.Length;
                }
                else
                {
                    extensionStatistics[extension] = new FileExtensionStats { FileCount = 1, TotalSize = file.Length };
                }
            }

            var totalFileCount = allFiles.Count;
            var totalFileSize = allFiles.Sum(f => f.Length);

            var orderedExtensions = extensionStatistics.OrderByDescending(ext => ext.Value.FileCount).ToList();

            Console.WriteLine("+----------+----------------+------------+-----------------+---------------------------+----------------------+");
            Console.WriteLine(
                "| {0, -8} | {1, -14} | {2, -10} | {3, -15} | {4, -25} | {5, -20} |",
                  "Number", "Extension", "File Count", "Total Size in B",
                  "% of Total Files", "% of Total Size");
            Console.WriteLine("+----------+----------------+------------+-----------------+---------------------------+----------------------+");

            int index = 1;
            foreach (var ext in orderedExtensions)
            {
                var stats = ext.Value;
                Console.WriteLine(
                    "| {0, -8} | {1, -14} | {2, -10} | {3, -15} | {4, -25} | {5, -20} |",
                      index++, ext.Key, stats.FileCount, stats.TotalSize,
                      $"{100.0 * stats.FileCount / totalFileCount:F2}%",
                      $"{100.0 * stats.TotalSize / totalFileSize:F2}%");
            }
            Console.WriteLine("+----------+----------------+------------+-----------------+---------------------------+----------------------+");
            Console.WriteLine(
                "| {0, -25} | {1, -10} | {2, -15} | {3, -25} | {4, -20} |",
                  "TOTAL:", $"{totalFileCount}", $"{totalFileSize}",
                  "100%", "100%");
            Console.WriteLine("+----------+----------------+------------+-----------------+---------------------------+----------------------+");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access to files or directories denied.");
        }
        Console.ReadLine();
    }

    static List<FileInfo> RetrieveAllFiles(DirectoryInfo directory, string searchPattern)
    {
        var fileList = new List<FileInfo>();
        foreach (var file in directory.GetFiles(searchPattern))
            fileList.Add(file);

        foreach (var subDirectory in directory.GetDirectories())
        {
            if (subDirectory.Name == "Documents" || subDirectory.Name == "Settings")
                continue;
            try
            {
                fileList.AddRange(RetrieveAllFiles(subDirectory, searchPattern));
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Access denied to {subDirectory.Name}");
            }
        }
        return fileList;
    }
}
