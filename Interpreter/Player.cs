using System;

namespace Interpreter
{
    internal class Player
    {
        public string ID
        {
            get;
            private set;
        }

        public bool Serving
        {
            get;
            set;
        }

        public Player(string playerID)
        {
            ID = playerID;
        }

        public void Change()
        {
            Serving = !Serving;
        }
    }
}
