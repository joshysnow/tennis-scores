using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public class ScoreInterpreter
    {
        private List<Match> _matches;

        public ScoreInterpreter()
        {
            _matches = new List<Match>();
        }

        public void Interpret(string match)
        {
            this.Interpret(new string[] { match });
        }

        public void Interpret(string[] matchLines)
        {
            if (matchLines != null)
            {
                Match match;

                foreach (string matchScores in matchLines)
                {
                    match = new Match();
                    match.ReadMatch(matchScores);
                    _matches.Add(match);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder matchScores = new StringBuilder();

            if (_matches != null)
            {
                foreach (Match match in _matches)
                {
                    matchScores.AppendLine(match.ToString());
                }
            }

            return matchScores.ToString();
        }
    }
}