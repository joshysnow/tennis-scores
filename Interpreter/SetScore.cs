namespace Interpreter
{
    internal class SetScore
    {
        public byte ServerScore
        {
            get;
            set;
        }

        public byte ReceiverScore
        {
            get;
            set;
        }

        public SetScore()
        {
            ServerScore = 0;
            ReceiverScore = 0;
        }

        public string FormatScore()
        {
            return ServerScore + "-" + ReceiverScore;
        }

        public void Swap()
        {
            byte serverScore = ServerScore;
            ServerScore = ReceiverScore;
            ReceiverScore = serverScore;
        }
    }
}
