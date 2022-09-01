using Tennis.Tests.Common;
using Xunit;

namespace Tennis.Tests
{
    public class TennisGame1Tests
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void GetScore_ReturnsExpectedScore(int score1, int score2, string expected)
        {
            // Arrange
            var player1 = new TennisPlayer("player1", score1);
            var player2 = new TennisPlayer("player2", score2);
            var game = new TennisGame1(player1, player2);

            // Assert
            Assert.Equal(expected, game.GetScore());
        }

        [Theory]
        [InlineData(0, 0, 1, 0, 1, 0)]
        [InlineData(0, 0, 0, 1, 0, 1)]
        public void WonPoint_IncreasesScore(int initialPoints1, int initialPoints2, int newPoints1, int newPoints2, int expected1, int expected2)
        {
            // Arrange
            var player1 = new TennisPlayer("player1", initialPoints1);
            var player2 = new TennisPlayer("player2", initialPoints2);
            var game = new TennisGame1(player1, player2);

            // Act
            ScoreAdder.AddScores(game, newPoints1, newPoints2);

            // Assert
            Assert.Equal(expected1, player1.Score);
            Assert.Equal(expected2, player2.Score);
        }

        [Theory]
        [InlineData(5, 4, "Sponge", "Bob", "Advantage Sponge")]
        [InlineData(4, 5, "Sponge", "Bob", "Advantage Bob")]
        [InlineData(4, 0, "Sponge", "Bob", "Win for Sponge")]
        [InlineData(0, 4, "Sponge", "Bob", "Win for Bob")]
        [InlineData(6, 4, "Sponge", "Bob", "Win for Sponge")]
        [InlineData(4, 6, "Sponge", "Bob", "Win for Bob")]
        public void GetScore_PersonalisedPlayerName_ReturnsExpectedScore(int score1, int score2, string name1, string name2, string expected)
        {
            // Arrange
            var player1 = new TennisPlayer(name1, score1);
            var player2 = new TennisPlayer(name2, score2);
            var game = new TennisGame1(player1, player2);

            // Assert
            Assert.Equal(expected, game.GetScore());
        }
    }
}
