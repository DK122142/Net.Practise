using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Practise
{
    public static class Task
    {
        public static void DigitsOfNumber()
        {
            int.TryParse(Console.ReadLine(), out var number);
            foreach (var digit in number.ToString())
            {
                Console.WriteLine(digit);
            }
        }

        public static void FractionInteger(double number)
        {
            var dividedNumber = number.ToString().Split(",");

            Console.WriteLine($"Number: {number} Fraction: {dividedNumber[1]}; Integer: {dividedNumber[0]}");
        }

        public static void MaxDigitOfNumber(int number)
        {
            var max = 0;

            foreach (var digit in number.ToString())
            {
                if (int.Parse(digit.ToString()) > max)
                {
                    max = int.Parse(digit.ToString());
                }
            }

            Console.WriteLine($"Number: {number} Max digit: {max}");
        }

        public static void MinDigitOfNumber(int number)
        {
            var min = int.Parse(number.ToString()[0].ToString());
            
            foreach (var digit in number.ToString())
            {
                if (int.Parse(digit.ToString()) < min)
                {
                    min = int.Parse(digit.ToString());
                }
            }

            Console.WriteLine($"Number: {number} Min digit: {min}");
        }

        public static void PrintOnlyDigits(string inputString)
        {
            foreach (var symbol in inputString)
            {
                if (int.TryParse(symbol.ToString(), out var digit))
                {
                    Console.WriteLine(digit);
                }
            }
        }

        public static void FormatCurrentDate()
        {
            Console.WriteLine(DateTime.Now.ToString("O"));
        }

        public static void ParseDate(string date)
        {
            Console.WriteLine(DateTime.ParseExact(date, "yyyy dd-MM", CultureInfo.InvariantCulture));
        }

        public static void ToUpperFirstLetter()
        {
            string[] names = {"иван иванов", "светлана иванова-петренко"};

            for (int i = 0; i < names.Length; i++)
            {
                var words = names[i].Split(new [] { " ","-" }, StringSplitOptions.None);
                for (int j = 0; j < words.Length; j++)
                {
                    names[i] = names[i].Replace(words[j], words[j].First().ToString().ToUpper() + words[j].Substring(1));
                }
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static void DecodeString(string encodedString)
        {
            Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(encodedString)));
        }

        public static void BubbleSort()
        {
            int[] array = new int[39];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(1, 100);
            }

            Console.WriteLine($"Initial array: {string.Join(",", array)}");

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
            
            Console.WriteLine($"Sorted array: {string.Join(",", array)}");
        }

        public static void TreeTraversal()
        {
            var tree = new TreeNode<int>(0)
            {
                Child = new List<TreeNode<int>>
                {
                    new TreeNode<int>(10)
                    {
                        Child = new List<TreeNode<int>>
                        {
                            new TreeNode<int>(11),
                            new TreeNode<int>(12)
                        }
                    },
                    new TreeNode<int>(20)
                    {
                        Child = new List<TreeNode<int>>
                        {
                            new TreeNode<int>(21),
                            new TreeNode<int>(22)
                        }
                    },
                    new TreeNode<int>(30)
                    {
                        Child = new List<TreeNode<int>>
                        {
                            new TreeNode<int>(31)
                        }
                    }
                }
            };

            Console.WriteLine("DFT:");
            foreach (TreeNode<int> node in tree.DepthFirstTraversal())
            {
                Console.WriteLine(node.Data);
            }

            Console.WriteLine("{0}BFT:", Environment.NewLine);
            foreach (TreeNode<int> node in tree.BreadthFirstTraversal())
            {
                Console.WriteLine(node.Data);
            }

// must produce this console output:
            // DFT:
            // 0
            // 10
            // 11
            // 12
            // 20
            // 21
            // 22
            // 30
            // 31
            //
            // BFT:
            // 0
            // 10
            // 20
            // 30
            // 11
            // 12
            // 21
            // 22
            // 31
        }
        
        public static void ZipArray()
        {
            int[] ints = new int[new Random().Next(10,40)];
            byte[] bytes = new byte[ints.Length * sizeof(int)];

            int[] decompressedInts = new int[ints.Length];
            byte[] decompressedBytes = new byte[ints.Length * sizeof(int)];

            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = new Random().Next(1, 100);
            }

            Console.WriteLine($"Int array: {string.Join(",", ints)}");
            
            Buffer.BlockCopy(ints, 0, bytes, 0, bytes.Length);

            Console.WriteLine($"Converted to byte array: {string.Join(",", bytes)}");

            using (var file = File.Create("array"))
            {
                using (var compress = new GZipStream(file, CompressionMode.Compress))
                {
                    compress.Write(bytes);
                }
            }

            using (var file = File.OpenRead("array"))
            {
                using (var decompress = new GZipStream(file, CompressionMode.Decompress))
                {
                    decompress.Read(decompressedBytes);
                }
            }

            Console.WriteLine($"Decompressed byte array: {string.Join(",", decompressedBytes)}");
            
            for (int i = 0; i < (decompressedBytes.Length / sizeof(int)); i++)
            {
                decompressedInts[i] = BitConverter.ToInt32(decompressedBytes, i * sizeof(int));
            }

            Console.WriteLine($"Converted to int array: {string.Join(",", decompressedInts)}");
        }

        public static void QuickSort()
        {
            
            int[] array = new int[39];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(1, 100);
            }

            Console.WriteLine($"Initial array: {string.Join(",", array)}");

            QuickSort(array, 0, array.Length - 1);

            Console.WriteLine($"Sorted array: {string.Join(",", array)}");
        }

        private static void QuickSort(int[] array, int start, int end)
        {
            int i = start;
            int j = end;

            var mid = array[(start + end) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(mid) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(mid) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    var tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }
            
            if (start < j)
            {
                QuickSort(array, start, j);
            }

            if (i < end)
            {
                QuickSort(array, i, end);
            }
        }
    }
}
