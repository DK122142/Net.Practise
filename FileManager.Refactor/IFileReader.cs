using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Refactor
{
    public interface IFileReader
    {
        int CharactersAmount { get; }

        List<string> Extensions { get; set; }

        string Read(string filePath);
    }
}
