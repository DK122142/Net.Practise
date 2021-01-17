using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Refactor
{
    public class TxtFileReader : IFileReader
    {
        public int CharactersAmount => 1024;
        public List<string> Extensions { get; set; }

        public TxtFileReader()
        {
            this.Extensions = new List<string>();

            this.Extensions.Add(".txt");
        }

        public string Read(string filePath)
        {
            int count = CharactersAmount;
            char[] result = new char[count];
            using (var reader = System.IO.File.OpenText(filePath))
                count = reader.Read(result, 0, count);
            return new string(result);
        }
    }
}
