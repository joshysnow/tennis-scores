using System;

namespace Interpreter
{
    internal class Set
    {
        private Game _game;
        private short _serverScore;
        private short _receiverScore;

        public Set()
        {
            _serverScore = 0;
            _receiverScore = 0;
        }

        public bool ReadScore(char score)
        {
            bool setWon = false;

            if (!char.IsWhiteSpace(score))
            {
                //_game = new Game();
                //_game.ReadScore(score);

                
            }

            return setWon;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
