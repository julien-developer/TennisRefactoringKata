using FakeItEasy;
using Xunit;

namespace Tennis.Tests
{
    public class TennisGame1Tests
    {
        private readonly IScorePresenter scorePresenter;

        public TennisGame1Tests()
        {
            scorePresenter = A.Fake<IScorePresenter>();
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
            var player1 = new Player("player1", initialPoints1, 0);
            var player2 = new Player("player2", initialPoints2, 0);
            var game = new TennisGame1(scorePresenter, player1, player2);

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
        public void WonPoint_WhenPlayerWins_ResetsScoreAndIncreasesGame(int points1, int points2, PlayerId scoringPlayer, int expected1, int expected2)
        {
            // Arrange
            var player1 = new Player("player1", points1, 0);
            var player2 = new Player("player2", points2, 0);
            var game = new TennisGame1(scorePresenter, player1, player2);

            // Act
            game.WonPoint(scoringPlayer);

            // Assert
            Assert.Equal(0, player1.Points);
            Assert.Equal(0, player2.Points);
            Assert.Equal(expected1, player1.Games);
            Assert.Equal(expected2, player2.Games);
        }
    }
}
