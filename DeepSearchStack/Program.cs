using System;
using System.Collections;

namespace DeepSearchStack
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new Searcher(new int[][]
            {
               new [] { 0, 11, 5, 1, 5},
               new []{ 11, 0, 8, 6, 10},
               new []{ 5, 8, 0, 2, 9},
               new []{ 1, 6, 2, 0, 1},
               new []{ 5, 10, 9, 1, 0}
            });
            foreach (var v in s.Search(0,1))
            {
                Console.Write($"{v}->");
            }


        }
    }
}