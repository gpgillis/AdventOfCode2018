using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AdventOfCode2018.Day11
{
    // --------------------------------------------------------------------
    public class Solver11
    {
        private const int _maxDimension = 300;

        // --------------------------------------------------------------------
        public string PuzzleA(int data)
        {
            Console.WriteLine("Solving for serial number {0}", data);
            var gs = new GridSolver();
            gs.BlockSizeLimit = 3;
            gs.LoadGrid(_maxDimension, data);
            gs.FindMaxPower();
            return string.Format("{0},{1}", gs.MaxIndex.X, gs.MaxIndex.Y);
        }

        public string PuzzleB(int data)
        {
            Console.WriteLine("Solving for serial number {0}", data);
            var gs = new GridSolver();
            gs.BlockSizeLimit = 300;
            gs.LoadGrid(_maxDimension, data);
            gs.FindMaxPower();
            return string.Format("{0},{1},{2}", gs.MaxIndex.X, gs.MaxIndex.Y, gs.MaxBlockSize);
        }
    }
}
