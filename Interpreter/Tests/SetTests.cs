using System.Threading;
using MbUnit.Framework;

namespace Interpreter.Tests
{
    [TestFixture]
    public class SetTests
    {
        [FixtureSetUp]
        public void Setup()
        {
            //Thread.Sleep(10000);
        }

        [FixtureTearDown]
        public void TearDown()
        {

        }

        [Test]
        public void EmptySet()
        {
            Player one = new Player('A');
            Player two = new Player('B');

            Set set = new Set(one, two);

            Assert.IsFalse(set.WinConditionMet());
            Assert.AreEqual("0-0", set.GetScore());
        }

        [Test]
        [Row("A", "0-0 15-0", false)]
        [Row("AAA", "0-0 40-0", false)]
        [Row("AAAA", "0-1", false)]
        [Row("AAAAB", "0-1 15-0", false)]
        [Row("AAAABBBB", "1-1", false)]
        [Row("AAAABBBBB", "1-1 0-15", false)]
        [Row("AAAABBBBA", "1-1 15-0", false)]
        public void Inputs(string input, string output, bool setWon)
        {
            Player one = new Player('A');
            Player two = new Player('B');
            one.Position = PlayerPosition.Server;
            two.Position = PlayerPosition.Receiver;

            Set set = new Set(one, two);

            char[] characters = input.ToCharArray();

            foreach (char character in characters)
            {
                set.ReadCharacter(character);   
            }

            string score = set.GetScore();
            Assert.AreEqual(setWon, set.WinConditionMet());
            Assert.AreEqual(output, set.GetScore());
        }
    }
}
