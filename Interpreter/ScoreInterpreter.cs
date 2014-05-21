using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public class ScoreInterpreter
    {
        public static ScoreInterpreter Instance
        {
            get
            {
                return _instance;
            }
            
        }

        private static readonly ScoreInterpreter _instance = new ScoreInterpreter();
        private List<Match> _matches;

        private ScoreInterpreter()
        {
            _matches = new List<Match>();
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
                    matchScores.Append(match.ToString());
                }
            }

            return matchScores.ToString();
        } 
    }
}