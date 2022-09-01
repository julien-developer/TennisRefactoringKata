using Tennis.Tests.Unit;
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
            var player1 = new TennisPlayer("player1", score1, 0);
            var player2 = new TennisPlayer("player2", score2, 0);
            var game = new TennisGame1(player1, player2);

            // Assert
            Assert.Equal(expected, game.GetPointScore());
        }

        [Theory]
        [InlineData(0, 0, PlayerId.First, 1, 0)]
        [InlineData(0, 0, PlayerId.Second, 0, 1)]
        [InlineData(3, 3, PlayerId.First, 4, 3)]
        [InlineData(3, 3, PlayerId.Second, 3, 4)]
        [InlineData(3, 4, PlayerId.First, 4, 4)]
        [InlineData(4, 3, PlayerId.Second, 4, 4)]
        [InlineData(4, 4, PlayerId.First, 5, 4)]
        [InlineData(4, 4, PlayerId.Second, 4, 5)]
        public void WonPoint_IncreasesScore(int initialPoints1, int initialPoints2, PlayerId scoringPlayer, int expected1, int expected2)
        {
            // Arrange
            var player1 = new TennisPlayer("player1", initialPoints1, 0);
            var player2 = new TennisPlayer("player2", initialPoints2, 0);
            var game = new TennisGame1(player1, player2);

            // Act
            game.WonPoint(scoringPlayer);

            // Assert
            Assert.Equal(expected1, player1.Points);
            Assert.Equal(expected2, player2.Points);
        }

        [Theory]
        [InlineData(3, 0, PlayerId.First, 1, 0)]
        [InlineData(0, 3, PlayerId.Second, 0, 1)]
        [InlineData(5, 3, PlayerId.First, 1, 0)]
        [InlineData(3, 5, PlayerId.Second, 0, 1)]
        [InlineData(6, 5, PlayerId.First, 1, 0)]
        [InlineData(5, 6, PlayerId.Second, 0, 1)]
        public void WonPoint_WhenPlayerLeads_ResetsScoreAndIncreasesGame(int points1, int points2, PlayerId scoringPlayer, int expected1, int expected2)
        {
            // Arrange
            var player1 = new TennisPlayer("player1", points1, 0);
            var player2 = new TennisPlayer("player2", points2, 0);
            var game = new TennisGame1(player1, player2);

            // Act
            game.WonPoint(scoringPlayer);

            // Assert
            Assert.Equal(0, player1.Points);
            Assert.Equal(0, player2.Points);
            Assert.Equal(expected1, player1.Games);
            Assert.Equal(expected2, player2.Games);
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
            var player1 = new TennisPlayer(name1, score1, 0);
            var player2 = new TennisPlayer(name2, score2, 0);
            var game = new TennisGame1(player1, player2);

            // Assert
            Assert.Equal(expected, game.GetPointScore());
        }

        [Theory]
        [InlineData(1, 0, "Sponge", "Bob", "Sponge 1 - 0 Bob")]
        [InlineData(0, 1, "Sponge", "Bob", "Sponge 0 - 1 Bob")]
        public void GetGamesWon_ReturnsExpectedGames(int gamesWon1, int gamesWon2, string name1, string name2, string expceted)
        {
            // Arrange
            var player1 = new TennisPlayer(name1, 0, gamesWon1);
            var player2 = new TennisPlayer(name2, 0, gamesWon2);
            var game = new TennisGame1(player1, player2);

            // Assert
            Assert.Equal(expceted, game.GetGameScore());
        }
    }
}
