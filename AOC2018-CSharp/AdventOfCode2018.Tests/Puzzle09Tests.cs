using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018.Day09;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Puzzle09Tests
    {
        private String[] TestData1 = new String[] { "10 players", "last marble is worth 1618 points" };     // High score = 8317
        private String[] TestData2 = new String[] { "13 players", "last marble is worth 7999 points" };     // High score = 146373
        private String[] TestData3 = new String[] { "17 players", "last marble is worth 1104 points" };     // High score = 2764
        private String[] TestData4 = new String[] { "21 players", "last marble is worth 6111 points" };     // High score = 54718
        private String[] TestData5 = new String[] { "30 players", "last marble is worth 5807 points" };     // High score = 37305

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestPuzzle09A()
        {
            var puz = new Solver09();
            var result = puz.PuzzleA(TestData1);
            Assert.AreEqual(8317, result);
            
            result = puz.PuzzleA(TestData2);
            Assert.AreEqual(146373, result);

            result = puz.PuzzleA(TestData3);
            Assert.AreEqual(2764, result);

            result = puz.PuzzleA(TestData4);
            Assert.AreEqual(54718, result);

            result = puz.PuzzleA(TestData5);
            Assert.AreEqual(37305, result);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void TestPuzzle09B()
        {
            var puz = new Solver09();
            var result = puz.PuzzleB(TestData1);
            Assert.AreEqual(74765078, result);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void P9_TestParseData()
        {
            var results = Solver09.ParseData(TestData1);
            Assert.AreEqual(2, results.Length);
            Assert.AreEqual(10, results[0]);
            Assert.AreEqual(1618, results[1]);
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void P9_TestGameBoardAddMarbleFull()
        {
            var board = new GameBoard();
            var removed = 0L;

            for (var i = 1; i <= 22; i++)
            {
                removed += board.AddMarble(i);
            }
            Assert.AreEqual(0, removed);
            Assert.AreEqual(22, board.GetCurrentMarble);
            Assert.AreEqual("0 16 8 17 4 18 9 19 2 20 10 21 5 22 11 1 12 6 13 3 14 7 15", board.ToString());

            board.Clear();
            for (var i = 1; i <= 23; i++)
            {
                removed += board.AddMarble(i);
            }
            Assert.AreEqual(32, removed);
            Assert.AreEqual(19, board.GetCurrentMarble);
            Assert.AreEqual("0 16 8 17 4 18 19 2 20 10 21 5 22 11 1 12 6 13 3 14 7 15", board.ToString());
            
            removed = 0;
            board.Clear();
            for (var i = 1; i <= 25; i++)
            {
                removed += board.AddMarble(i);
            }

            Assert.AreEqual(32, removed);
            Assert.AreEqual(25, board.GetCurrentMarble);
            Assert.AreEqual("0 16 8 17 4 18 19 2 24 20 25 10 21 5 22 11 1 12 6 13 3 14 7 15", board.ToString());
        }

        // --------------------------------------------------------------------
        [TestMethod]
        public void P9_TestGameBoardAddMarble()
        {
            var board = new GameBoard();
            var removed = 0L;

            for (var i = 1; i <= 4; i++)
            {
                removed += board.AddMarble(i);
            }
            Assert.AreEqual(0, removed);
            Assert.AreEqual(4, board.GetCurrentMarble);
            Assert.AreEqual("0 4 2 1 3", board.ToString());

            board.Clear();
            for (var i = 1; i <= 22; i++)
            {
                removed += board.AddMarble(i);
            }
            Assert.AreEqual(0, removed);
            Assert.AreEqual(22, board.GetCurrentMarble);
            Assert.AreEqual("0 16 8 17 4 18 9 19 2 20 10 21 5 22 11 1 12 6 13 3 14 7 15", board.ToString());

        }
    }
}
