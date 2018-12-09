using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2018.Day07;

namespace AdventOfCode2018.Day07
{
    public class Puzzle07 : Puzzle
    {
        public static string DATANAME = "AdventOfCode2018.Day07.data.txt";

        public async override Task<string> PuzzleA()
        {
            var rules = await LoadStepRules();
            return new Solver07().PuzzleA(rules);
        }

        public async override Task<string> PuzzleB()
        {
            var rules = await LoadStepRules();
            return new Solver07().PuzzleB(rules, 5, 60);
        }

        public async Task<StepRules> LoadStepRules()
        {
            var data = await GetInput(DATANAME);

            var rules = new StepRules();
            foreach (var d in data)
            {
                rules.AddRule(d);
            }

            return rules;
        }

        private async Task<IEnumerable<string>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
