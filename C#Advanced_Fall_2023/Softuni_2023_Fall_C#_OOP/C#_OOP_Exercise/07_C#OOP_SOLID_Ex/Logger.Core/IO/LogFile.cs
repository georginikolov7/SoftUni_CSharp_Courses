using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4U.Core.IO
{
    public class LogFile : ILogFile
    {
        private static readonly string DefaultName = $"log";
        private static readonly string DefaultPath = $"{Directory.GetCurrentDirectory()}";
        private static readonly string DefaultExtention = ".txt";
        private string name;
        private string path;
        private string extention;
        public LogFile()
        {
            Name = DefaultName;
            path = DefaultPath;
            extention = DefaultExtention;
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                name = value;
            }
        }
        public string Path
        {
            get
            {
                return path;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Path cannot be null or empty");
                }
                if (!Directory.Exists(path))
                {
                    throw new ArgumentException("Invalid file path");
                }
                path = value;
            }
        }
        public string Extention
        {
            get
            {
                return extention;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Extention cannot be null or empty");
                }
                extention = value;
            }
        }
        public string FullPath => System.IO.Path.GetFullPath($"{Path}/{Name}.{Extention}");
        public int Size => File.ReadAllText(Path).Length;
    }
}
