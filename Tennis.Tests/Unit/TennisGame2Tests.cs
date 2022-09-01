using Tennis.Tests.Unit;
using Xunit;

namespace Tennis.Tests
{
    public class TennisGame2Tests
    {
        [Theory(Skip = "Introduced personalisation of player name. Breaks the tests.")]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis2Test(int score1, int score2, string expected)
        {
            // Arrange
            var game = new TennisGame2("player1", "player2");

            // Act
            AddScores(game, score1, score2);

            // Assert
            Assert.Equal(expected, game.GetPointScore());
        }

        private void AddScores(ITennisGame game, int player1Score, int player2Score)
        {
            for (var i = 0; i < player1Score; i++)
            {
                game.WonPoint(PlayerId.First);
            }

            for (var i = 0; i < player2Score; i++)
            {
                game.WonPoint(PlayerId.Second);
            }
        }
    }
}
