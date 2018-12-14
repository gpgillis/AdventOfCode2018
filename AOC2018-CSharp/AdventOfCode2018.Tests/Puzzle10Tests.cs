using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Puzzle10Tests
    {
        // --------------------------------------------------------------------
        [TestMethod]
        public void P10_TestLoadTestData()
        {
            var solver = new AdventOfCode2018.Day10.Day10Solver();
            solver.LoadTestData();
            Assert.AreNotEqual(0, solver.LoadedDataCount);
            Assert.AreNotEqual(0, solver.LoadedPointDataCount);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void P10_TestLoadProductionData()
        {
            var solver = new AdventOfCode2018.Day10.Day10Solver();
            solver.LoadProductionData();
            Assert.AreNotEqual(0, solver.LoadedDataCount);
            Assert.AreNotEqual(0, solver.LoadedPointDataCount);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void P10_TestSolveNext()
        {
            var solver = new AdventOfCode2018.Day10.Day10Solver();
            solver.Normalizer = new Point(600, 600);
            solver.LoadTestData();
            Assert.AreNotEqual(0, solver.LoadedDataCount);
            Assert.AreNotEqual(0, solver.LoadedPointDataCount);
            for (int i = 0; i < 5; i++)
            {
                var data = new List<Point>(solver.SolveNext());
                Assert.AreNotEqual(0, data.Count);
            }
        }

        //// --------------------------------------------------------------------
        //[TestMethod]
        //public void P10_TestGeneratePointsFromDataLine()
        //{
        //    var solver = new AdventOfCode2018.Day10.Day10Solver();
        //    var points = solver.GeneratesPointPairsFromDataLine("position=< 9,  1> velocity=< 0,  2>");
        //    Assert.AreEqual(2, points.Length);
        //    Assert.AreEqual(9, points[0].X);
        //    Assert.AreEqual(1, points[0].Y);
        //    Assert.AreEqual(0, points[1].X);
        //    Assert.AreEqual(2, points[1].Y);
        //}

        //// --------------------------------------------------------------------
        //[TestMethod]
        //public void P10_TestGeneratePointFromSegment()
        //{
        //    var solver = new AdventOfCode2018.Day10.Day10Solver();
        //    var point = solver.GeneratePointFromSegment("position=< 9,  1>");
        //    Assert.AreEqual(9, point.X);
        //    Assert.AreEqual(1, point.Y);
        //}
    }
}
