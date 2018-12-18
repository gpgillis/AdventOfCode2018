namespace AdventOfCode2018.Console
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Console = System.Console;
    using AdventOfCode2018.Day06;
    using AdventOfCode2018.Day07;
    using AdventOfCode2018.Day08;
    using AdventOfCode2018.Day09;
    using AdventOfCode2018.Day11;

    class Program
    {
        private static IDictionary<int, IPuzzle> puzzles = new Dictionary<int, IPuzzle>()
        {
            {6, new Puzzle06()},
            {7, new Puzzle07()},
            {8, new Puzzle08()},
            {9, new Puzzle09()},
            {11, new Puzzle11()}
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

            Console.WriteLine("Starting " + puzzle.PuzzleName);

            Console.WriteLine("Solving puzzle A ... ");
            await Execute(puzzle.PuzzleA());
            Console.WriteLine();
            
            Console.WriteLine("Solving puzzle B ...");
            await Execute(puzzle.PuzzleB());
            Console.WriteLine();

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
            Console.WriteLine("Time taken: {0} ms", watch.Elapsed.TotalMilliseconds);
        }
    }
}
