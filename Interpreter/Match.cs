using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter
{
    internal class Match
    {
        private List<Set> _sets;

        public Match()
        {
            _sets = new List<Set>();
        }

        public void ReadMatch(string matchScores)
        {
            Player one = new Player('A');
            Player two = new Player('B');

            one.Position = PlayerPosition.Server;
            two.Position = PlayerPosition.Receiver;

            Set set = new Set(one, two);
            _sets.Add(set);

            char[] scores = matchScores.ToCharArray();

            for (int i = 0; i < scores.Length; i++)
            {
                set.ReadCharacter(scores[i]);

                if (set.WinConditionMet())
                {
                    set = new Set(one, two);
                }
            }
        }

        public string GetMatchScore()
        {
            StringBuilder setScores = new StringBuilder();

            foreach (Set set in _sets)
            {
                setScores.Append(set.GetScore());
                setScores.Append(" ");
            }

            return setScores.ToString();
        }
    }
}
