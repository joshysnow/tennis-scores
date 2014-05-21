using System;

namespace Interpreter
{
    internal class Game
    {
        private Player _a;
        private Player _b;
        private GameScore _serverScore;
        private GameScore _receiverScore;

        public Game(Player a, Player b)
        {
            _a = a;
            _b = b;
            _serverScore = GameScore.LOVE;
            _receiverScore = GameScore.LOVE;
        }

        public bool ReadScore(char score)
        {
            bool gameWon = false;

            if (char.IsWhiteSpace(score))
            {

            }
            else if ((_serverScore == GameScore.ADVANTAGE) || (_receiverScore == GameScore.ADVANTAGE))
            {

            }
            else
            {

            }

            return gameWon;
        }

        public override string ToString()
        {
            return _serverScore + "-" + _receiverScore + string.Empty;
        }
    }
}
