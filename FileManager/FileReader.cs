using System;
using System.IO;

namespace FileManager
{
    public class FileReader
    {
        public static bool IsTxt(string fileName)
        {
            return new FileInfo(fileName).Extension.Equals(".txt");
        }

        public void ReadTxt(string fileName)
        {
            var buffer = new char[1024];

            using (var reader = new StreamReader(fileName))
            {
                var amount = reader.Read(buffer, 0, 1024);

                Console.WriteLine(string.Join("", buffer));
            }
        }
        
        public void ReadAnotherFile(string fileName)
        {
            var buffer = new byte[2048];
            // var text = new char[buffer.Length / 2];
            string hexText;

            using (var reader = File.OpenRead(fileName))
            {
                var amount = reader.Read(buffer, 0, 2048);

                var toRead = amount > buffer.Length ? buffer.Length : amount;
                
                // for (int i = 0; i < toRead; i++)
                // {
                //     text[i] = BitConverter.ToChar(buffer, i * 2);
                // }

                hexText = Convert.ToHexString(buffer, 0, toRead);

                Console.WriteLine(hexText);
            }
        }
    }
}
