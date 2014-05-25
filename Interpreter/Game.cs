namespace Interpreter
{
    internal sealed class Game : IReader
    {
        private GameScore _serverScore;
        private GameScore _receiverScore;

        public Game()
        {
            _serverScore = GameScore.LOVE;
            _receiverScore = GameScore.LOVE;
        }

        public override bool WinConditionMet()
        {
            return false;
        }

        protected override void ExtractValue(char character)
        {

            if (char.IsWhiteSpace(character))
            {
                // Do nothing.
            }
            else if ((_serverScore == GameScore.ADVANTAGE) || (_receiverScore == GameScore.ADVANTAGE))
            {
                // Win.
            }
            else
            {
                // Up score.
                // If receiver, increase receiver score
                // If server, increase server score
            }
        }

        protected override void CalculateWinCondition()
        {
            
        }

        public override string ToString()
        {
            return _serverScore + "-" + _receiverScore;
        }
    }
}
