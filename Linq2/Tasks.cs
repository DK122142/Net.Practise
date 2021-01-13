using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2
{
    public static class Tasks
    {
        public static void Task1()
        {
            Console.WriteLine(string.Join(",", Enumerable.Range(10, 41)));
        }
        public static void Task2()
        {
            Console.WriteLine(string.Join(",", Enumerable.Range(10, 41).Where(n => n % 3 == 0)));
        }

        public static void Task3()
        {
            Console.WriteLine(string.Join("", Enumerable.Repeat("Linq", 10)));
        }

        public static void Task4()
        {
            var str = "aaa; abb; ccc; dap";

            Console.WriteLine(string.Join(";", str
                .Split(";").Where(w => w.Contains("a"))));
        }

        public static void Task5()
        {
            var str = "aaa; abb; ccc; dap";

            Console.WriteLine(string.Join(",", str
                .Split("; ").Select(w => w
                .Count(c => c.Equals('a')))));
        }

        public static void Task6()
        {
            var str = "aaa; abb; ccc; dap";

            Console.WriteLine(str.Split("; ").Contains("abb"));
        }
        
        public static void Task7()
        {
            var str = "aaa; xabbx; abb; ccc; dap";

            Console.WriteLine(str.Split("; ").OrderByDescending(w => w.Length).FirstOrDefault());
        }

        public static void Task8()
        {
            var str = "aaa; xabbx; abb; ccc; dap";

            Console.WriteLine(str.Split("; ").Average(w => w.Length));
        }
        
        public static void Task9()
        {
            var str = "aaa; xabbx; abb; ccc; dap; zh";

            Console.WriteLine(string.Join("", str.Split("; ")
                .OrderBy(w => w.Length)
                .FirstOrDefault().Reverse()));
        }
        
        public static void Task10()
        {
            var str = "baaa; aabb; aaa; xabbx; abb; ccc; dap; zh";

            Console.WriteLine(str.Split("; ")
                .FirstOrDefault(w => w.StartsWith("aa"))
                .Skip(2).All(s => s.Equals('b')));
        }
        
        public static void Task11()
        {
            var str = "baaa; aabb; aaa; xabbx; abb; ccc; dap; zh";

            Console.WriteLine(str.Split("; ").LastOrDefault(w => !w.EndsWith("bb")));
        }
    }
}
