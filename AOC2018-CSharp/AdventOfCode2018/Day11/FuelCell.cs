using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day11
{
    public class FuelCell
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int SerialNumber { get; private set; }

        private int _powerLevel = int.MinValue;

        // --------------------------------------------------------------------
        public FuelCell(int x, int y, int sn)
        {
            X = x;
            Y = y;
            SerialNumber = sn;
        }

        // --------------------------------------------------------------------
        public int GetPowerLevel()
        {
            if (_powerLevel == int.MinValue)
            {
                var rackID = X + 10;
                var powerLevel = ((rackID * Y) + SerialNumber) * rackID;
                powerLevel = GetHundredsValue(powerLevel);
                _powerLevel = powerLevel - 5;
            }

            return _powerLevel;
        }

        // --------------------------------------------------------------------
        // Returns the hundreds value from provided integer or zero if val is less than 100.
        // ie: 12345 return 3, 789456123 returns 1, 87 return 0.
        private int GetHundredsValue(int val)
        {
            if (val < 100)
                return 0;

            var s = val.ToString();
            return int.Parse(s.Substring(s.Length - 3, 1));
        }
    }
}
