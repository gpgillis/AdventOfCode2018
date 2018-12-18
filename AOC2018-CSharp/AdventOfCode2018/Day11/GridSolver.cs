using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AdventOfCode2018.Day11
{
    public class GridSolver
    {
        public int MaxDimension { get; set; }

        private FuelCell[,] _grid;
        private int[,] _mockGrid;
        private Point _maxIndex = new Point(0, 0);
        private int _maxBlockSize = 0;


        public Point MaxIndex { get { return _maxIndex; } }
        public int MaxBlockSize { get { return _maxBlockSize; } }
        public int BlockSizeLimit { get; set; }
        public int GridSize { get { return (_grid == null) ? 0 : _grid.Length;}}
        public int MockGridSize { get { return (_mockGrid == null) ? 0 : _mockGrid.Length; } }

        // --------------------------------------------------------------------
        public void LoadGrid(int maxDimension, int serialNumber)
        {
            MaxDimension = maxDimension;
            _mockGrid = null;
            _grid = new FuelCell[MaxDimension, MaxDimension];
            for (int x = 0; x < MaxDimension; x++)
            {
                for (int y = 0; y < MaxDimension; y++)
                {
                    var cell = new FuelCell(x + 1, y + 1, serialNumber);
                    _grid[x, y] = cell;
                }
            }
        }

        // --------------------------------------------------------------------
        public void LoadMockGrid(int maxDimension, int[,] mock)
        {
            MaxDimension = maxDimension;
            _grid = null;
            _mockGrid = mock;
        }

        // --------------------------------------------------------------------
        public void FindMaxPower()
        {
            var max = 0;
            Point maxIndex = new Point(0, 0);
            var skipBlockSize = new HashSet<int>();

            for (var blockSize = 1; blockSize <= BlockSizeLimit; blockSize++)
            { 
                if (skipBlockSize.Contains(blockSize))
                    continue;

                var maxPowerForBlockSize = int.MinValue;
                for (var x = 0; x < MaxDimension - blockSize; x++)
                {
                    for (var y = 0; y < MaxDimension - blockSize; y++)
                    {
                        var power = CalculatePower(x, y, blockSize);
                        maxPowerForBlockSize = (power > maxPowerForBlockSize) ? power : maxPowerForBlockSize;

                        if (power > max)
                        {
                            max = power;
                            _maxBlockSize = blockSize;
                            _maxIndex = new Point(x + 1, y + 1);
                        }
                    }
                }

                if (maxPowerForBlockSize < 0)
                    break;
            }
        }

        // --------------------------------------------------------------------
        private int CalculatePower(int x, int y, int blockSize)
        {
            var power = 0;

            for (int i = x; i < x + blockSize; i++)
            {
                for (int j = y; j < y + blockSize; j++)
                {
                    if (_grid != null)
                        power = power + _grid[i, j].GetPowerLevel();
                    else if (_mockGrid != null)
                        power = power + _mockGrid[i, j];
                }
            }

            return power;
        }
    }
}
