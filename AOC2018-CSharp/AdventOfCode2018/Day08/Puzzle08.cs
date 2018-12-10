using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day08
{
    public class Puzzle08 : Puzzle
    {
        private static string DATAFILE = "AdventOfCode2018.Day08.data.txt";

        public override string PuzzleName { get { return "Puzzle 08"; } }

        // --------------------------------------------------------------------
        public async override Task<string> PuzzleA()
        {
            var data = await GetInput(DATAFILE);
            var solver = new Solver08();
            return solver.PuzzleA(data).ToString();
        }

        // --------------------------------------------------------------------
        public async override Task<string> PuzzleB()
        {
            var data = await GetInput(DATAFILE);
            var solver = new Solver08();
            return solver.PuzzleB(data).ToString();
        }

        // --------------------------------------------------------------------
        public async Task<int> TestLoadInput()
        {
            var data = await GetInput(DATAFILE);
            return data.ToArray().Length;
        }

        // --------------------------------------------------------------------
        private async Task<IEnumerable<int>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
        }

    }
}
