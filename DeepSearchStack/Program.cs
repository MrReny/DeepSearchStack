using System;

namespace DeepSearchStack
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var rnd = new Random();
            var n = 5;
            var rndG = new int[][]
            {
                new[] {0, 11, 5, 1, 5},
                new[] {11, 0, 8, 6, 10},
                new[] {5, 8, 0, 2, 9},
                new[] {1, 6, 2, 0, 1},
                new[] {5, 10, 9, 1, 0}
            };

            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    rndG[i][j] = rnd.Next(0, 100);
                    rndG[j][i] = rndG[i][j];
                }
            }
            rndG.PrintArray();
            Console.WriteLine();


            var r = new Searcher(rndG);
            foreach (var v in r.Search(0,4))
            {
                Console.Write($"{v}->");
            }
            Console.WriteLine();


            var sArr = new int[][]
            {
                new[] {0, 11, 5, 1, 5},
                new[] {11, 0, 8, 6, 10},
                new[] {5, 8, 0, 2, 9},
                new[] {1, 6, 2, 0, 1},
                new[] {5, 10, 9, 1, 0}
            };
            sArr.PrintArray();


            var s = new Searcher(sArr);
            foreach (var v in s.Search(0,4))
            {
                Console.Write($"{v}->");
            }

            Console.WriteLine();


        }
    }
}