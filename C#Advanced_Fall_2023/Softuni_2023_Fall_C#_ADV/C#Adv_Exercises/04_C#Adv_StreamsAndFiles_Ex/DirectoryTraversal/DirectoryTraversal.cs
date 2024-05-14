namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)+ @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> extensionsFiles = new();
            string[] files = Directory.GetFiles(inputFolderPath);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string currentExtension = GetExtention(fileInfo.Name);
                //Check if current ext already exists in dictionary:
                if (!extensionsFiles.ContainsKey(currentExtension))
                {
                    extensionsFiles.Add(currentExtension, new());
                }
                //No need to check if file exists as there cannot be 2 files with the same name
                //Add the file to the dictionary with its size in kb:
                extensionsFiles[currentExtension].Add(fileInfo);
            }

            //format output:
            StringBuilder sb = new();
            foreach (var kvp1 in extensionsFiles.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
            {
                sb.AppendLine(kvp1.Key);
                foreach (var fileInfo in kvp1.Value.OrderBy(x => x.Length))
                {
                    sb.AppendLine($"--{fileInfo.Name} - {fileInfo.Length / 1024.0}kb");
                }
            }
            return sb.ToString();
        }

        private static string GetExtention(string name)
        {
            int positionOfLastDot = name.LastIndexOf('.');
            string extension = name.Substring(positionOfLastDot, name.Length - positionOfLastDot);
            return extension;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            File.WriteAllText(reportFileName, textContent);
        }
    }
}
