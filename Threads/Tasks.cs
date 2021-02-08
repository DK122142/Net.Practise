using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Threads
{
    public static class Tasks
    {
        public static int[] CreateArray()
        {
            var processors = Environment.ProcessorCount;
            var elements = 10_000;
            var elPerProc = elements / processors;

            int[] array = new int[elements];

            var threads = new List<Thread>();
            
            for (int i = 0; i < processors; i++)
            {
                var tmp = i;
                var from = tmp * elPerProc;
                var to = i == processors - 1 ? array.Length : (tmp + 1) * elPerProc;

                var thread = new Thread(() => FillArray(from, to));
                thread.Start();
                threads.Add(thread);
            }
            
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return array;

            void FillArray(int start, int end)
            {
                for (int j = start; j < end; j++)
                {
                    array[j] = new Random().Next(1, 1000);
                }
            }
        }

        public static int[] SubArray(int[] array, int start, int end)
        {
            var processors = Environment.ProcessorCount;
            var elements = end - start;
            var elPerProc = elements / processors;
            int[] subArray = new int[elements];
            var threads = new List<Thread>();

            for (int i = 0; i < processors; i++)
            {
                var tmp = i;
                var from = tmp * elPerProc;
                var to = i == processors - 1 ? subArray.Length : (tmp + 1) * elPerProc;

                var thread = new Thread(() => CopyArray(from, to));
                thread.Start();
                threads.Add(thread);
            }
            
            foreach (var thread in threads)
            {
                thread.Join();
            }
            
            return subArray;

            void CopyArray(int _start, int _end)
            {
                for (int j = _start; j < _end; j++)
                {
                    subArray[j] = array[j + start];
                }
            }
        }

        public static int MinInArray(int[] array)
        {
            var min = array.First();
            var processors = Environment.ProcessorCount;
            var elements = array.Length;
            var elPerProc = elements / processors;

            var threads = new List<Thread>();

            for (int i = 0; i < processors; i++)
            {
                var tmp = i;
                var from = tmp * elPerProc;
                var to = i == processors - 1 ? array.Length : (tmp + 1) * elPerProc;

                var thread = new Thread(() => FindMin(from, to));
                thread.Start();
                threads.Add(thread);
            }
            
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return min;

            void FindMin(int _start, int _end)
            {
                for (int j = _start; j < _end; j++)
                {
                    if (array[j] < min)
                    {
                        min = array[j];
                    }
                }
            }
        }

        public static int AverageInArray(int[] array)
        {
            var totalAvg = 0;
            var processors = Environment.ProcessorCount;
            var elements = array.Length;
            var elPerProc = elements / processors;

            var threads = new List<Thread>();
            var avgs = new List<int>();

            for (int i = 0; i < processors; i++)
            {
                var tmp = i;
                var from = tmp * elPerProc;
                var to = i == processors - 1 ? array.Length : (tmp + 1) * elPerProc;

                var thread = new Thread(() => Average(from, to));
                thread.Start();
                threads.Add(thread);
            }
            
            foreach (var thread in threads)
            {
                thread.Join();
            }

            totalAvg = avgs.Sum() / avgs.Count;
            
            return totalAvg;

            void Average(int _start, int _end)
            {
                var sum = 0;
                
                for (int j = _start; j < _end; j++)
                {
                    sum += array[j];
                }

                var avg = sum / (_end - _start);

                avgs.Add(avg);
            }
        }
    }
}
