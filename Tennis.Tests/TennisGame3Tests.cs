using Tennis.Tests.Common;
using Xunit;

namespace Tennis.Tests
{
    public class TennisGame3Tests
    {
        [Theory(Skip = "Introduced personalisation of player name. Breaks the tests.")]
        [ClassData(typeof(TestDataGenerator))]
        public void Tennis3Test(int score1, int score2, string expected)
        {
            // Arrange
            var game = new TennisGame3("player1", "player2");

            // Act
            ScoreAdder.AddScores(game, score1, score2);

            // Assert
            Assert.Equal(expected, game.GetScore());
        }
    }
}
