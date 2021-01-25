using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class BullsCows
    {
        public static List<string> List = new ();
        public static int Count;

        public static void Start()
        {
            List = CombinationsGenerator.GenerateCombinations();

            while (!ToGuess()) { }
        }

        public static bool ToGuess()
        {
            int guess = GenerateNumberFromList();

            Count++;

            string guessStr = guess.ToString();

            if (guessStr.Length == 3) {
                guessStr = '0' + guessStr;
            }

            Console.WriteLine();
            Console.WriteLine("Round " + Count + ": " + guessStr);

            Console.Write("Bulls: "); 

            int.TryParse(Console.ReadLine(), out var bull);

            Console.Write("Cows: ");

            int.TryParse(Console.ReadLine(), out var cow);

            if (bull < 0 || bull > 4 || cow < 0 || cow > 4)
            {
                Console.WriteLine("Number between 0 and 4");
                Count--;
                Start();
            }
            else if (bull == 4 && cow == 0){
                Console.WriteLine("Your number is " + guessStr);
                return true;
            }

            CheckList(bull, cow, guess);

            if (List.Count == 1)
            {
                guessStr = List[0];

                if (guessStr.Length == 3) {
                    guessStr = '0' + guessStr;
                }

                Console.WriteLine();
                Console.WriteLine("Confirm round: " + Count + ": " + guessStr);

                Console.Write("Bulls: ");

                int b = int.Parse(Console.ReadLine());

                Console.Write("Cows: ");

                int c = int.Parse(Console.ReadLine());

                if (b != 4 || c != 0)
                {
                    Console.WriteLine("Something went wrong");
                }
                else if (b == 4 && c == 0)
                {
                    Console.WriteLine("Number is " + guessStr);
                    return true;
                }

                return true;
            }

            if (List.Count == 0){
                Console.WriteLine("Something went wrong");
                return true;
            }

            return false;
        }

        public static void CheckList(int bull, int cow, int guess) {
            var newList = new List<string>();
            
                foreach (var combination in List)
                {
                    List<string> bullsAndCows = BullsAndCows(guess, int.Parse(combination));

                    if (bull == int.Parse(bullsAndCows[0]) && cow == int.Parse(bullsAndCows[1]))
                    {
                        newList.Add(combination);
                    }
                }
                List = newList;
        }

        public static List<string> BullsAndCows(int guess, int ans) {
            var bc = new List<string>();
            int b = 0;
            int c = 0;

            var ansArray = ArrayFromInt(ans);
            var guessArray = ArrayFromInt(guess);

            for (int i = 0; i < 4; i++) {
                if (guessArray[i] == ansArray[i])
                {
                    b++;
                }
                else {
                    for (int j = 0; j < 4; j++)
                    {
                        if (guessArray[j] == ansArray[i]) {
                            c++;
                        }
                    }
                }
            }
            
            bc.Add(string.Join("", b));
            bc.Add(string.Join("", c));

            return bc;
        }

        public static int[] ArrayFromInt(int number)
        {
            int[] result = new int[4];

            result[0] = number / 1000;
            result[1] = (number / 100) % 10;
            result[2] = (number / 10) % 10;
            result[3] = number % 10;

            return result;
        }

        public static int GenerateNumberFromList() {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            int index = rnd.Next(1, List.Count);
            var number = int.Parse(List[index]);
            return number;
        }
    }
}
