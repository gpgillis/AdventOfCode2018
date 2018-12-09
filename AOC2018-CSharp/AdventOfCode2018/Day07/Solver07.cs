using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day07
{
    public class Solver07
    {
        // --------------------------------------------------------------------
        public string PuzzleA(StepRules rules)
        {
            var sequence = new List<string>();

            while (true)
            {
                var ready = rules.GetNextReadyStep();
                if (String.IsNullOrEmpty(ready))
                    break;

                sequence.Add(ready);
                rules.RemoveDependency(ready);
            }

            return String.Join(String.Empty, sequence);
        }

        // --------------------------------------------------------------------
        public string PuzzleB(StepRules rules, int availableWorkers, int timeAdder = 0)
        {
            int seconds = 0;
            var wp = new WorkProcessor(availableWorkers);
            wp.TimeAdder = timeAdder;

            List<string> ready;

            while (true)
            {
                ready = rules.GetReadySteps();
                wp.LoadWorkQueue(ref ready);

                if (wp.IsTaskQueueEmpty())
                    break;

                var completed = wp.ProcessQueue();
                seconds++;

                rules.RemoveDependencies(completed);
            }

            return seconds.ToString();
        }
    }
}
