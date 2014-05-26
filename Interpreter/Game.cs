namespace Interpreter
{
    internal sealed class Game : IReader
    {

        public GameScore ServerScore
        {
            get;
            private set;
        }

        public GameScore ReceiverScore
        {
            get;
            private set;
        }

        public Player PlayerOne
        {
            get;
            private set;
        }

        public Player PlayerTwo
        {
            get;
            private set;
        }

        private GameScore _serverPrevious;
        private GameScore _receiverPrevious;
        private bool _gameWon;

        public Game(Player one, Player two)
        {
            PlayerOne = one;
            PlayerTwo = two;

            ServerScore = GameScore.LOVE;
            ReceiverScore = GameScore.LOVE;

            _gameWon = false;
        }

        public override bool WinConditionMet()
        {
            return _gameWon;
        }

        public override string GetScore()
        {
            return ServerScore.ToString() + "-" + ReceiverScore.ToString();
        }

        protected override void Update(char character)
        {
            if (character == PlayerOne.CharIdentifier)
            {
                UpdatePlayer(PlayerOne);
            }
            
            if (character == PlayerTwo.CharIdentifier)
            {
                UpdatePlayer(PlayerTwo);
            }
        }

        protected override void Analyse()
        {
            if ((ServerScore == GameScore.ADVANTAGE && _serverPrevious == ServerScore) || (ReceiverScore == GameScore.ADVANTAGE && _receiverPrevious == ReceiverScore))
            {
                _gameWon = true;
            }

            if ((ServerScore > GameScore.FORTY) && (_serverPrevious == GameScore.FORTY) && (ServerScore > ReceiverScore))
            {
                _gameWon = true;
            }

            if ((ReceiverScore > GameScore.FORTY) && (_receiverPrevious == GameScore.FORTY) && (ReceiverScore > ServerScore))
            {
                _gameWon = true;
            }
        }

        private void UpdatePlayer(Player player)
        {
            if (player.Position == PlayerPosition.Server)
            {
                _serverPrevious = ServerScore;
                ServerScore = ServerScore.Increase();

                if (ServerScore == GameScore.ADVANTAGE && ReceiverScore == GameScore.ADVANTAGE)
                {
                    ReceiverScore.Decrease();
                }
            }
            else
            {
                _receiverPrevious = ReceiverScore;
                ReceiverScore = ReceiverScore.Increase();

                if (ReceiverScore == GameScore.ADVANTAGE && ServerScore == GameScore.ADVANTAGE)
                {
                    ServerScore.Decrease();
                }
            }
        }
    }
}