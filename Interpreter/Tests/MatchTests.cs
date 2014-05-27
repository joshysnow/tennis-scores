using MbUnit.Framework;

namespace Interpreter.Tests
{
    [TestFixture]
    public class MatchTests
    {
        [FixtureSetUp]
        public void Setup()
        {

        }
        
        [FixtureTearDown]
        public void TearDown()
        {

        }

        [Test]
        [Row(" ", "0-0 ")]
        [Row("B", "0-0 0-15 ")]
        public void Inputs(string input, string output)
        {
            Match match = new Match();
            match.ReadMatch(input);
            Assert.AreEqual(output, match.GetMatchScore());
        }
    }
}
