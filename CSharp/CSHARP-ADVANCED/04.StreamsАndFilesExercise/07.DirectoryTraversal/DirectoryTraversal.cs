using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);
            Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extention = fileInfo.Extension;
                long size = fileInfo.Length;

                if (!filesDictionary.ContainsKey(extention))
                {
                    filesDictionary[extention] = new List<FileInfo>();
                }

                filesDictionary[extention].Add(fileInfo);
            }

            filesDictionary = filesDictionary
                             .OrderByDescending(x => x.Value.Count)
                             .ThenBy(x => x.Key)
                             .ToDictionary(x => x.Key, y => y.Value);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = desktop + "/report.txt";

            using (StreamWriter writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in filesDictionary)
                {
                    string extention = pair.Key;
                    var fileInfos = pair.Value.OrderByDescending(x => x.Length);

                    writer.WriteLine(extention);

                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double)fileInfo.Length / 1024;

                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                    }
                }
            }
        }
    }
}
