using System;
using System.Linq;

namespace FileManager
{
    public class Explorer
    {
        public ExplorerService ExplorerService { get; set; }

        public Explorer()
        {
            this.ExplorerService = new ExplorerService();
            
            Console.Write($"{ExplorerService.CurrentDirectory} ");
        }

        public void ShowContent()
        {
            Console.Clear();

            ExplorerService.ShowDirectoryContent();

            Console.WriteLine();
            Console.Write($"{ExplorerService.CurrentDirectory} ");
        }

        public void GoTo(string path)
        {
            Console.Clear();

            if (path.Equals(".."))
            {
                ExplorerService.GoBack();
            }
            else
            {
                ExplorerService.SetDirectory(path);
            }
            
            Console.Write($"{ExplorerService.CurrentDirectory} ");
        }

        public void ReadFile(string path)
        {
            Console.Clear();

            if (FileReader.IsTxt(path))
            {
                new FileReader().ReadTxt(path);
            }
            else
            {
                new FileReader().ReadAnotherFile(path);
            }

            Console.Write($"{ExplorerService.CurrentDirectory} ");
        }

        public void Execute(string input)
        {
            var args = input.Split(" ");

            switch (args.FirstOrDefault())
            {
                case "cd":
                    GoTo(args[1]);
                    break;
                case "r":
                    ReadFile(args[1]);
                    break;
                case "ls":
                    ShowContent();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "":
                    Console.Write($"{ExplorerService.CurrentDirectory} ");
                    break;
                default:
                    Console.WriteLine("Unavailable operation");
                    break;
            }
        }

    }
}
