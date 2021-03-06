﻿namespace Interpreter
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

        public GameScore Increase()
        {
            GameScore newScore;

            switch (_value)
            {
                case _LOVE:
                    newScore = FIFTEEN;
                    break;
                case _FIFTEEN:
                    newScore = THIRTY;
                    break;
                case _THIRTY:
                    newScore = FORTY;
                    break;
                case _FORTY:
                    newScore = ADVANTAGE;
                    break;
                case _ADVANTAGE:
                    newScore = this;
                    break;
                default:
                    newScore = LOVE;
                    break;
            }

            return newScore;
        }

        public GameScore Decrease()
        {
            GameScore newScore;

            if (_value == _ADVANTAGE)
            {
                newScore = FORTY;
            }
            else
            {
                newScore = this;
            }

            return newScore;
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

        public static bool operator >(GameScore left, GameScore right)
        {
            return ((left._value > right._value) && (right != ADVANTAGE)) || ((left == ADVANTAGE) && (right != ADVANTAGE));
        }

        public static bool operator <(GameScore left, GameScore right)
        {
            return right > left;
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
