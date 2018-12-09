using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Puzzle6Tests
    {
        private static IEnumerable<Point> TestData1 = new[]
        {
            new Point(1,1),
            new Point(1,6),
            new Point(8,3),
            new Point(3,4),
            new Point(5,5),
            new Point(8,9),
        };

        [TestMethod]
        public void TestPuzzle6A()
        {
            var solver = new Day06.Solver06();
            var s = solver.PuzzleA(TestData1);
            Assert.AreEqual(s, 17);
        }

        [TestMethod]
        public void TestPuzzle6B()
        {
            var solver = new Day06.Solver06();
            var s = solver.PuzzleB(TestData1, 32);
            Assert.AreEqual(s, 16);
        }

    }
}
