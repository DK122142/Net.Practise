using System;
using System.IO;
using System.Linq;

namespace FileManager
{
    public class ExplorerService
    {
        public string CurrentDirectory { get; private set; }

        public ExplorerService()
        {
            SetDirectory(@"C:\");
        }

        public void SetDirectory(string directoryPath)
        {
            Directory.SetCurrentDirectory(directoryPath);
            CurrentDirectory = Directory.GetCurrentDirectory();
        }

        public void GoBack()
        {
            var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent;

            if (directoryInfo != null)
            {
                SetDirectory(directoryInfo.FullName);
            }
            else
            {
                Console.WriteLine("No parent for this directory");
            }
        }

        public void ShowDirectoryContent()
        {
            var directories = Directory.EnumerateDirectories(CurrentDirectory)
                .Where(d => !new DirectoryInfo(d).Attributes.HasFlag(FileAttributes.Hidden));

            var files = Directory.EnumerateFiles(CurrentDirectory)
                .Where(d => !new FileInfo(d).Attributes.HasFlag(FileAttributes.Hidden));

            foreach (var directory in directories)
            {
                Console.WriteLine(directory.Replace(CurrentDirectory, string.Empty)
                    .Replace("\\", string.Empty));
            }

            foreach (var file in files)
            {
                Console.WriteLine(file.Replace(CurrentDirectory, string.Empty)
                    .Replace("\\", string.Empty));
            }
        }
    }
}
