namespace CopyDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(inputPath);
            DirectoryInfo outputDir = new DirectoryInfo(outputPath);
            if (outputDir.Exists)
            {
                outputDir.Delete(true);
            }
            outputDir.Create();
            List<FileInfo> files = directoryInfo.GetFiles().ToList();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(outputPath,file.Name));
            }
        }
    }
}
