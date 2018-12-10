namespace AdventOfCode2018.Day06
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;

    public class Puzzle06 : Puzzle
    {
        private static string DATANAME = "AdventOfCode2018.Day06.data.txt";

        public override string PuzzleName { get { return "Puzzle 06"; } }

        // --------------------------------------------------------------------
        public async override Task<string> PuzzleA()
        {
            var input = await this.GetInput(DATANAME);
            return new Solver06().PuzzleA(input).ToString();
        }

        // --------------------------------------------------------------------
        public async override Task<string> PuzzleB()
        {
            var input = await this.GetInput(DATANAME);
            return new Solver06().PuzzleB(input, 10000).ToString();
        }

        // --------------------------------------------------------------------
        private async Task<IEnumerable<Point>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    var split = x
                        .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    return new Point(split[0], split[1]);
                });
        }
    }
}