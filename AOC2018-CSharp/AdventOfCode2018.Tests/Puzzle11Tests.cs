using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using AdventOfCode2018.Day11;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Puzzle11Tests
    {

        private int[,] _mockGrid = new int[,] {{-2,  -4,   4,   4,   4}, {-4,   4,   4,   4,  -5}, { 4,   3,   3,   4,  -4}, { 1,   1,   2,   4,  -3}, {-1,   0,   2,  -5,  -2}};
        // --------------------------------------------------------------------
        [TestMethod]
        public void TestPuzzle11A()
        {
            var solver = new Solver11();
            var ans = solver.PuzzleA(18);
            Assert.AreEqual("33,45", ans);
            solver = null;

            solver = new Solver11();
            ans = solver.PuzzleA(42);
            Assert.AreEqual("21,61", ans);
            solver = null;
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestPuzzle11B()
        {
            var solver = new Solver11();
            var ans = solver.PuzzleB(18);
            Assert.AreEqual("90,269,16", ans);
            solver = null;

            solver = new Solver11();
            ans = solver.PuzzleB(42);
            Assert.AreEqual("232,251,12", ans);
            solver = null;
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void P11_TestFuelCellPowerLevelCalculation()
        {
            var fuelCell = new FuelCell(122, 79, 57);
            var powerlevel = fuelCell.GetPowerLevel();
            Assert.AreEqual(-5, powerlevel);

            fuelCell = new FuelCell(217, 196, 39);
            powerlevel = fuelCell.GetPowerLevel();
            Assert.AreEqual(0, powerlevel);

            fuelCell = new FuelCell(101, 153, 71);
            powerlevel = fuelCell.GetPowerLevel();
            Assert.AreEqual(4, powerlevel);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void P11_TestGridLoading()
        {
            var gs = new GridSolver();
            gs.LoadGrid(300, 9995);
            Assert.AreEqual(90000, gs.GridSize);
            Assert.AreEqual(0, gs.MockGridSize);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void P11_TestMockGridLoading()
        {
            var gs = new GridSolver();
            gs.LoadMockGrid(5, _mockGrid);
            Assert.AreEqual(25, gs.MockGridSize);
            Assert.AreEqual(0, gs.GridSize);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void P11_TestFindMaxPowerMockGrid()
        {
            var gs = new GridSolver();
            gs.LoadMockGrid(5, _mockGrid);
            gs.BlockSizeLimit = 3;
            gs.FindMaxPower();
            var maxIdx = gs.MaxIndex;
            Assert.AreEqual(2, maxIdx.X);
            Assert.AreEqual(2, maxIdx.Y);
        }
    }
}
