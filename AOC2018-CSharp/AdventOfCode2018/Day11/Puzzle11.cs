using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day11
{
    public class Puzzle11 : Puzzle
    {
        private static string DATAFILE = "AdventOfCode2018.Day11.data.txt";

        public override string PuzzleName { get { return "Puzzle 11"; } }

        // --------------------------------------------------------------------
        public async override Task<string> PuzzleA()
        {
            var data = await GetInput(DATAFILE);
            var solver = new Solver11();
            return solver.PuzzleA(int.Parse(data.ToArray()[0]));
        }

        // --------------------------------------------------------------------
        public async override Task<string> PuzzleB()
        {
            var data = await GetInput(DATAFILE);
            var solver = new Solver11();
            return solver.PuzzleB(int.Parse(data.ToArray()[0]));
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
