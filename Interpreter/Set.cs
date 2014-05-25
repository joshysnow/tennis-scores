using System.Collections.Generic;

namespace Interpreter
{
    internal sealed class Set : IReader
    {
        private List<Game> _games;
        private Game _current;
        private bool _setWon;

        public Set()
        {
            _games = new List<Game>();
            _current = new Game();
        }

        public override bool WinConditionMet()
        {
            return _setWon;
        }

        protected override void ExtractValue(char character)
        {
            _current.ReadCharacter(character);

            if (_current.WinConditionMet())
            {
                _games.Add(_current);
                _current = new Game();
            }
        }

        protected override void CalculateWinCondition()
        {
            // Check minimum number of games has been completed.
            if (_games.Count >= 6)
            {
                foreach (Game game in _games)
                {
                    // Get each score for both players.
                }
            }
            else
            {
                _setWon = false;
            }
        }
    }
}
