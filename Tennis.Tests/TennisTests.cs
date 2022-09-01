using Xunit;

namespace Tennis.Tests
{

    public class TennisTests
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis1Test(int p1, int p2, string expected)
        {
            var game = new TennisGame1("player1", "player2");
            CheckAllScores(game, p1, p2, expected);
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis2Test(int p1, int p2, string expected)
        {
            var game = new TennisGame2("player1", "player2");
            CheckAllScores(game, p1, p2, expected);
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis3Test(int p1, int p2, string expected)
        {
            var game = new TennisGame3("player1", "player2");
            CheckAllScores(game, p1, p2, expected);
        }

        private void CheckAllScores(ITennisGame game, int player1Score, int player2Score, string expectedScore)
        {
            for (var i = 0; i < player1Score; i++)
            {
                game.WonPoint("player1");
            }

            for (var i = 0; i < player2Score; i++)
            {
                game.WonPoint("player2");
            }

            Assert.Equal(expectedScore, game.GetScore());
        }
    }
}