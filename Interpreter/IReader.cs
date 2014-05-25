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
            ExtractValue(character);
            CalculateWinCondition();
        }

        public abstract bool WinConditionMet();

        protected virtual void ExtractValue(char character)
        {

        }

        protected virtual void CalculateWinCondition()
        {

        }
    }
}
