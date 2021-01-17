using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Refactor
{
    public class UnsupportedExtFileReader : IFileReader
    {
        public int CharactersAmount => 2048;
        public List<string> Extensions { get; set; }

        public UnsupportedExtFileReader()
        {
            Extensions = new List<string>();
        }

        public string Read(string filePath)
        {
            int count = this.CharactersAmount;
            byte[] result = new byte[count];
            using (var stream = System.IO.File.OpenRead(filePath))
                count = stream.Read(result, 0, count);
            return BitConverter.ToString(result, 0, count).Replace('-', ' ');
        }

        public bool Supports(string extension)
        {
            return true;
        }
    }
}
