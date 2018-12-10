using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day08
{
    public class Solver08
    {
        // --------------------------------------------------------------------
        public int PuzzleA(IEnumerable<int> data)
        {
            var node = LoadNodes(data);
            return node.SumMetaDataPartA();
        }

        // --------------------------------------------------------------------
        public int PuzzleB(IEnumerable<int> data)
        {
            var node = LoadNodes(data);
            return node.SumMetaDataPartB();
        }

        public Node LoadNodes(IEnumerable<int> data)
        {
            var node = new Node();
            int idx = 0;
            node.PopulateNode(ref idx, data.ToArray());
            return node;
        }
    }
}
