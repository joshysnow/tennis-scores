using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    internal abstract class IReader
    {
        public void ReadCharacter(char character)
        {
            Update(character);
            Analyse();
        }

        public abstract bool WinConditionMet();

        public abstract string GetScore();

        protected virtual void Update(char character)
        {

        }

        protected virtual void Analyse()
        {

        }
    }
}
