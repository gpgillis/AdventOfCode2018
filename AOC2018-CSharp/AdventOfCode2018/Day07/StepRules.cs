using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day07
{
    public class StepRules
    {
        private Dictionary<String, HashSet<String>> rules = new Dictionary<string, HashSet<string>>();

        public Dictionary<String, HashSet<String>> Rules { get { return rules; } }

        // --------------------------------------------------------------------
        public void Clear()
        {
            rules.Clear();
        }

        // --------------------------------------------------------------------
        // Initializes StepRules from data line
        // Sample data line : 'Step Y must be finished before step E can begin.'
        public void AddRule(String data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("Data can not be empty.");

            var seg = data.Split( new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (seg.Length != 10)
                throw new ArgumentException("Invalid data line format found.");

            var name = seg[7];
            var dependency = seg[1];

            if (!rules.ContainsKey(name))
            {
                rules.Add(name, new HashSet<string>());
            }

            rules[name].Add(dependency);

            // If the dependency for this rule is not in our rules, add it since it may not have any dependencies.
            if (!rules.ContainsKey(dependency)) {
                rules.Add(dependency, new HashSet<string>());
            }
        }

        // --------------------------------------------------------------------
        public void AddRules(IEnumerable<string> data)
        {
            foreach (var d in data)
            {
                AddRule(d);
            }
        }

        // --------------------------------------------------------------------
        // Returns all steps that are ready for production.
        public List<String> GetReadySteps()
        {
            var rtn = new List<String>(Rules.Where(x => x.Value.Count == 0)
                .Select(x => x.Key));
            rtn.Sort();

            return rtn;
        }

        // --------------------------------------------------------------------
        // Returns the next ready step.  If more than one step is ready, the first step in alphabetical order is returned.
        public String GetNextReadyStep()
        {
            var rtn = GetReadySteps();
            return rtn.Count > 0 ? rtn[0] : string.Empty;
        }

        // --------------------------------------------------------------------
        // Removes step from the rules and the dependencies of any rule that has a dependency on step.
        public void RemoveDependency(String step)
        {
            if (Rules.ContainsKey(step))
                Rules.Remove(step);

            foreach (var rule in Rules.Keys)
            {
                if (Rules[rule].Contains(step))
                {
                    Rules[rule].Remove(step);
                }
            }
        }

        // --------------------------------------------------------------------
        // Removes step from the rules and the dependencies of any rule that has a dependency on step.
        public void RemoveDependencies(List<String> steps)
        {
            foreach (var step in steps)
            {
                RemoveDependency(step);
            }
        }
    }
}
