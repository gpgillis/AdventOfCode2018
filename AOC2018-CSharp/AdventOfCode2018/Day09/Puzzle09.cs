using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day09
{
    public class Puzzle09 : Puzzle
    {
        private static string DATAFILE = "AdventOfCode2018.Day09.data.txt";

        public override string PuzzleName { get { return "Puzzle 08"; } }

        // --------------------------------------------------------------------
        public async override Task<string> PuzzleA()
        {
            var data = await GetInput(DATAFILE);
            var solver = new Solver09();
            return solver.PuzzleA(data).ToString();
        }

        // --------------------------------------------------------------------
        public async override Task<string> PuzzleB()
        {
            var data = await GetInput(DATAFILE);
            var solver = new Solver09();
            return solver.PuzzleB(data).ToString();
        }

        // --------------------------------------------------------------------
        private async Task<IEnumerable<string>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
        }
    }
}
