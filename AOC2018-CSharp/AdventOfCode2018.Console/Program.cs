namespace AdventOfCode2018.Console
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    //using AdventOfCode2018.Day01;
    //using AdventOfCode2018.Day02;
    //using AdventOfCode2018.Day03;
    //using AdventOfCode2018.Day04;
    //using AdventOfCode2018.Day05;
    using AdventOfCode2018.Day06;
    using AdventOfCode2018.Day07;
    //using AdventOfCode2018.Day08;
    using Console = System.Console;

    class Program
    {
        private static IDictionary<int, IPuzzle> puzzles = new Dictionary<int, IPuzzle>()
        {
            //{1, new Day01Puzzle()},
            //{2, new Day02Puzzle()},
            //{3, new Day03Puzzle()},
            //{4, new Day04Puzzle()},
            //{5, new Day05Puzzle()},
            {6, new Puzzle06()},
            {7, new Puzzle07()},
            //{8, new Day08Puzzle()}
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code Solver!");
            MainAsync(args).Wait();
        }

        private static async Task MainAsync(string[] args)
        {
            Console.Write("Enter the puzzle number to solve: ");
            var puzzleNumber = int.Parse(Console.ReadLine());

            var puzzle = puzzles[puzzleNumber];

            Console.WriteLine("Solving puzzle A ... ");
            await Execute(puzzle.PuzzleA());
            Console.WriteLine("Solving puzzle B ...");
            await Execute(puzzle.PuzzleB());

            Console.WriteLine("Solution complete - press any key to continue.");
            Console.Read();
        }

        private static async Task Execute(Task<string> solution)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                Console.WriteLine(await solution);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            watch.Stop();
            Console.WriteLine("Time taken: {0}ms", watch.Elapsed.TotalMilliseconds);
        }
    }
}
