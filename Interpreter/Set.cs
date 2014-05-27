using System;
using System.Linq;
using System.Collections.Generic;

namespace Interpreter
{
    internal sealed class Set : IReader
    {
        private List<Game> _games;
        private Player _one;
        private Player _two;
        private bool _setWon;
        private bool _validCharacter;

        public Set(Player one, Player two)
        {
            _games = new List<Game>();
            _one = one;
            _two = two;
            _setWon = false;
            _validCharacter = false;
        }

        public override bool WinConditionMet()
        {
            return _setWon;
        }

        public override string GetScore()
        {
            // If the set hasn't been won when this has been called
                // Then the scores need to be added up to the last game.
                // Each time the server swaps so it is clear that scores need to follow this pattern


            // If the set has been won, then swap the scores over every time for each set
                // The server won? Add score. Swap. Server won? increment right or left?

            string score = string.Empty;

            if (WinConditionMet() || _games.Count == 0)
            {
                SetScore setScore = GetSetScore(_games);
                score = setScore.FormatScore();
            }
            else
            {
                List<Game> gamesClone = _games.GetRange(0, _games.Count);
                Game lastGame = gamesClone.Last();

                if (!lastGame.WinConditionMet())
                {
                    gamesClone.Remove(lastGame);
                }

                SetScore setScore = GetSetScore(gamesClone);
                score = lastGame.WinConditionMet() ? setScore.FormatScore() : setScore.FormatScore() + " " + lastGame.GetScore();
            }

            return score;
        }

        protected override void Update(char character)
        {
            if (WinConditionMet())
            {
                return;
            }

            _validCharacter = ValidateCharacter(character);

            if (!_validCharacter)
            {
                return;
            }

            if (_games.Count == 0 || _games.Last().WinConditionMet())
            {
                CreateNewGame();
            }

            _games.Last().ReadCharacter(character);
        }

        protected override void Analyse()
        {
            if (_games.Count == 0 || !_validCharacter)
            {
                return;
            }

            Game current = _games.Last();

            if (current.WinConditionMet())
            {
                // Swap the players.
                Player.SwapPositions(_one, _two);

                // Check minimum number of games has been completed.
                if (_games.Count >= 6)
                {
                    SetScore score = GetSetScore(_games);

                    byte difference = (byte)Math.Abs(score.ServerScore - score.ReceiverScore);

                    if (difference >= 2)
                    {
                        _setWon = true;
                    }
                }
            }
        }

        private void CreateNewGame()
        {
            _games.Add(new Game((Player)_one.Clone(), (Player)_two.Clone()));
        }

        private SetScore GetSetScore(List<Game> games)
        {
            SetScore score = new SetScore();

            foreach (Game game in games)
            {
                if (game.WinConditionMet())
                {
                    if (game.ServerScore > game.ReceiverScore)
                    {
                        // Increase left.
                        score.ServerScore++;
                    }
                    else
                    {
                        // Increase right.
                        score.ReceiverScore++;
                    }

                    score.Swap();
                }
            }

            return score;
        }

        private bool ValidateCharacter(char character)
        {
            return _one.CharIdentifier == character || _two.CharIdentifier == character;
        }
    }
}
