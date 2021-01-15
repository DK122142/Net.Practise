using System;

namespace FileManager
{
    public static class Input
    {
        public static Explorer Explorer { get; set; }

        public static void Start()
        {
            while (Process()) ;
        }

        public static bool Process()
        {
            try
            {
                var cmd = Console.ReadLine() ?? string.Empty;

                Explorer.Execute(cmd);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}. Message: {e.Message}");

                return false;
            }
        }

    }
}
