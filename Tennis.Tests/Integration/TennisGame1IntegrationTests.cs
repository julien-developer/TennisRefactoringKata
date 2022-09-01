using Xunit;

namespace Tennis.Tests.Integration
{
    public class TennisGame1IntegrationTests
    {
        [Theory]
        [ClassData(typeof(IntegrationTestData))]
        public void Games_WhenRunningPointSequence_ReturnsExpectedNumbers(int[] pointSequence, int expectedGames1, int expectedGames2, string expectedScore)
        {
            // Arrange
            var scorePresenter = new ScorePresenter();
            var player1 = new Player("player1", 0, 0);
            var player2 = new Player("player2", 0, 0);
            var game = new TennisGame1(scorePresenter, player1, player2);

            // Act
            for (int i = 0; i < pointSequence.Length; i++)
            {
                var playerId = (PlayerId)pointSequence[i];
                game.WonPoint(playerId);
            }

            // Assert
            Assert.Equal(expectedGames1, player1.Games);
            Assert.Equal(expectedGames2, player2.Games);
            Assert.Equal(expectedScore, game.GetPointScore());
        }
    }
}
