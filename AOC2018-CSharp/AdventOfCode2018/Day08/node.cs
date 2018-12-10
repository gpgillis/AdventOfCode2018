using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day08
{
    public class Node
    {
        private int _expectedChildCount;
        private int _expectedMetaCount;

        private List<Node> _childNodes = new List<Node>();
        public List<Node> ChildNodes { get { return _childNodes; } }

        private List<int> _metadata = new List<int>();
        public List<int> MetaData { get { return _metadata; }}

        // --------------------------------------------------------------------
        public void AddChild(Node child)
        {
            ChildNodes.Add(child);
            _expectedChildCount--;
        }

        // --------------------------------------------------------------------
        public void AddMetadata(int data)
        {
            MetaData.Add(data);
            _expectedMetaCount--;
        }

        // --------------------------------------------------------------------
        public void PopulateNode(ref int currentIndex, int[] data)
        {
            _expectedChildCount = data[currentIndex];
            currentIndex++;

            _expectedMetaCount = data[currentIndex];

            while(_expectedChildCount > 0)
            {
                currentIndex++;
                var child = new Node();
                child.PopulateNode(ref currentIndex, data);
                AddChild(child);
            }

            while(_expectedMetaCount > 0)
            {
                currentIndex++;
                AddMetadata(data[currentIndex]);
            }
        }

        // --------------------------------------------------------------------
        public int SumMetaDataPartA()
        {
            int sum = MetaData.Sum();
            foreach (var c in ChildNodes)
            {
                sum += c.SumMetaDataPartA();
            }

            return sum;
        }

        // --------------------------------------------------------------------
        public int SumMetaDataPartB()
        {
            int sum = 0;

            if (ChildNodes.Count == 0)
            {
                sum = MetaData.Sum();
            }
            else
            {
                foreach (var m in MetaData)
                {
                    if (m - 1 < ChildNodes.Count)
                    {
                        sum += ChildNodes[m - 1].SumMetaDataPartB();
                    }
                }
            }

            return sum;
        }
    }
}
