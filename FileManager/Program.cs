using System;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Input.Explorer = new Explorer();

            Input.Start();
        }
    }
}
