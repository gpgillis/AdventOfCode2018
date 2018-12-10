using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018.Day08;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Puzzle08Tests
    {
        // --------------------------------------------------------------------
        private static int[] TestData = new int[] {2, 3, 0, 3, 10, 11, 12, 1, 1, 0, 1, 99, 2, 1, 1, 2};

        // --------------------------------------------------------------------
        [TestMethod]
        public void P8_TestLoadInput()
        {
            var puz = new Puzzle08();
            var result = puz.TestLoadInput();
            Assert.IsFalse(result.IsFaulted, "Faulted - is data file available and set as an embedded resource?");
            Assert.IsNull(result.Exception, "Had an exception.");
            Assert.IsInstanceOfType(result.Result, typeof(int), "Result is not an integer.");
            Assert.AreNotEqual(0, result.Result, "Result is 0.");
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void P8_TestNodeLoading()
        {
            // We are only testing a couple of select nodes here to verify this test passes.
            // The thought is that if the root node has the correct number of children, the
            // correct number of metadata items and the correct meta data, then all subsequent
            // processing of the data into nodes should be correct.  We also spot test the first
            // child node of the root node for additional verification.

            var node = new Node();
            var index = 0;
            node.PopulateNode(ref index, TestData);

            Assert.AreEqual(2, node.ChildNodes.Count);
            Assert.AreEqual(3, node.MetaData.Count);
            Assert.AreEqual(1, node.MetaData[0]);
            Assert.AreEqual(1, node.MetaData[1]);
            Assert.AreEqual(2, node.MetaData[2]);

            Assert.AreEqual(0, node.ChildNodes[0].ChildNodes.Count);
            Assert.AreEqual(3, node.ChildNodes[0].MetaData.Count);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestPuzzle08A()
        {
            var solver = new Solver08();
            var result = solver.PuzzleA(TestData);
            Assert.AreEqual(138, result);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestPuzzle08B()
        {
            var solver = new Solver08();
            var result = solver.PuzzleB(TestData);
            Assert.AreEqual(66, result);
        }
    }
}
