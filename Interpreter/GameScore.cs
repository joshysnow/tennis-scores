using System;

namespace Interpreter
{
    internal struct GameScore
    {
        private byte _value;
        private const byte _LOVE            = 0x00;
        private const byte _FIFTEEN         = 0x15;
        private const byte _THIRTY          = 0x30;
        private const byte _FORTY           = 0x40;
        private const byte _ADVANTAGE       = 0x0A;

        public static GameScore LOVE        = new GameScore(_LOVE);
        public static GameScore FIFTEEN     = new GameScore(_FIFTEEN);
        public static GameScore THIRTY      = new GameScore(_THIRTY);
        public static GameScore FORTY       = new GameScore(_FORTY);
        public static GameScore ADVANTAGE   = new GameScore(_ADVANTAGE);

        private GameScore(byte type)
        {
            _value = type;
        }

        public GameScore Next()
        {
            GameScore nextScore;

            switch (_value)
            {
                case _LOVE:
                    nextScore = LOVE;
                    break;
                case _FIFTEEN:
                    nextScore = THIRTY;
                    break;
                case _THIRTY:
                    nextScore = FORTY;
                    break;
                case _FORTY:
                    nextScore = ADVANTAGE;
                    break;
                case _ADVANTAGE:
                    nextScore = this;
                    break;
                default:
                    nextScore = FIFTEEN;
                    break;
            }

            return nextScore;
        }

        public static bool operator ==(GameScore left, GameScore right)
        {
            if ((object)left == null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(GameScore left, GameScore right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if(!(obj is GameScore))
            {
                return false;
            }

            return _value == ((GameScore)obj)._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0:X}", _value);
        }
    }
}
