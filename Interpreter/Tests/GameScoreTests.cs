using MbUnit.Framework;

namespace Interpreter.Tests
{
    [TestFixture]
    public class GameScoreTests
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
        public void GreaterThan()
        {
            GameScore one = GameScore.ADVANTAGE;
            GameScore two = GameScore.FORTY;
            bool result = one > two;
            Assert.IsTrue(result);
            result = two > one;
            Assert.IsFalse(result);
        }

        [Test]
        public void LessThan()
        {
            
        }
    }
}
