using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day09
{
    //
    // Game board is implemented as a doubly linked list of Marble objects.
    //
    public class GameBoard
    {
        private Marble _currentMarble = null;
        private Marble _firstMarble = null;     // Holder object simply to run ToString in a repeatable order.
        public int GetCurrentMarble { get { return (_currentMarble != null) ? _currentMarble.Value : 0; } }

        // --------------------------------------------------------------------
        public GameBoard()
        {
            Clear();
        }

        // --------------------------------------------------------------------
        public void Clear()
        {
            _firstMarble = null;
            _currentMarble = null;
            _currentMarble = new Marble(0, null, null);
            _currentMarble.Next = _currentMarble;
            _currentMarble.Previous = _currentMarble;
            _firstMarble = _currentMarble;
        }

        // --------------------------------------------------------------------
        public long AddMarble(int marbleNumber)
        {
            var removed = 0L;

            if (marbleNumber % 23 == 0)
            {
                removed += (long)marbleNumber;
                for (int i = 0; i < 7; i++)
                {
                    _currentMarble = _currentMarble.Previous;
                }

                removed += _currentMarble.Value;
                _currentMarble.Previous.Next = _currentMarble.Next;
                _currentMarble.Next.Previous = _currentMarble.Previous;
                _currentMarble = _currentMarble.Next;
            }
            else
            {
                for (int i = 1; i < 3; i++)
                {
                    _currentMarble = _currentMarble.Next;
                }
    
                var insert = new Marble(marbleNumber, _currentMarble.Previous, _currentMarble);
                InsertMarble(_currentMarble, insert);
                _currentMarble = insert;
            }

            return removed;
        }

        // --------------------------------------------------------------------
        private void InsertMarble(Marble current, Marble insert)
        {
            current.Previous.Next = insert;
            current.Previous = insert;
        }

        // --------------------------------------------------------------------
        public override string ToString()
        {
            var target = _firstMarble;
            var sb = new StringBuilder();

            while (target.Next != _firstMarble)
            {
                sb.AppendFormat("{0} ", target.Value);
                target = target.Next;
            }

            sb.Append(target.Value);
            return sb.ToString().Trim();
        }
    }

    // --------------------------------------------------------------------
    public class Marble
    {
        public Marble(int val, Marble prev, Marble next)
        {
            Value = val;
            Previous = prev;
            Next = next;
        }

        public int Value { get; private set; }
        public Marble Previous { get; set; }
        public Marble Next { get; set; }
    }
}
