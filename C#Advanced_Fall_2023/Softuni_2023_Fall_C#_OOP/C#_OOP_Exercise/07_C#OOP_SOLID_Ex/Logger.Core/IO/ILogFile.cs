using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4U.Core.IO
{
    public interface ILogFile
    {
        string Name { get; }
        string Extention { get; }
        string Path { get; }
        string FullPath { get; }
        int Size { get; }
    }
}
