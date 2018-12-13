using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day09
{
    public class Solver09
    {
        private GameBoard _board = new GameBoard();
        Dictionary<int, long> _playerScores = new Dictionary<int, long>();

        // --------------------------------------------------------------------
        public long PuzzleA(IEnumerable<String> data, int multiplier = 1)
        {
            var d = Solver09.ParseData(data);
            int numberOfPlayers = d[0];
            int maxMarbleVal = d[1] * multiplier;

            _board.Clear();
            _playerScores.Clear();

            int player = 1;
            for (int currentMarble = 1; currentMarble <= maxMarbleVal; currentMarble++, player++)
            {
                if (player > numberOfPlayers)
                    player = 1;

                var score = _board.AddMarble(currentMarble);
                if (score > 0)
                {
                    if (!_playerScores.ContainsKey(player))
                        _playerScores.Add(player, 0);

                    _playerScores[player] = _playerScores[player] + score;
                }
            }

            return _playerScores.Values.Max();
        }

        // --------------------------------------------------------------------
        public long PuzzleB(IEnumerable<String> data)
        {
            return PuzzleA(data, 100);
        }

        // --------------------------------------------------------------------
        public static int[] ParseData(IEnumerable<String> data)
        {
            var d = data.ToArray();

            if (d.Length != 2)
                throw new ArgumentException("There should be two data strings.");

            int numOfPlayers = int.Parse(d[0].Substring(0, d[0].IndexOf("players") - 1).Trim());
            var worthIdx = d[1].IndexOf("worth") + "worth".Length;  // Index of the end of "worth"
            var pointsIdx = d[1].IndexOf("points") - 1;
            int lastMarbleVal = int.Parse(d[1].Substring(worthIdx, pointsIdx - worthIdx));
            return new int[] {numOfPlayers, lastMarbleVal};
        }
    }
}
