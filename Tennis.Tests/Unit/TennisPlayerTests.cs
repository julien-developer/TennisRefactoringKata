using Xunit;

namespace Tennis.Tests.Unit
{
    public class TennisPlayerTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(3, 4)]
        [InlineData(6, 7)]
        public void Points_WhenIncreasePoints_ReturnsExpectedValue(int initialPoints, int expectedPoints)
        {
            // Arrange
            var player = new TennisPlayer("SpongeBob", initialPoints, 0);

            // Act
            player.IncreasePoints();

            // Assert
            Assert.Equal(expectedPoints, player.Points);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 0)]
        public void Games_WhenIncreasePoints_RemainsTheSame(int initialPoints, int initialGames)
        {
            // Arrange
            var player = new TennisPlayer("SpongeBob", initialPoints, initialGames);

            // Act
            player.IncreasePoints();

            // Assert
            Assert.Equal(initialGames, player.Games);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(9)]
        public void Points_WhenIncreaseGamesAndResetPoints_EqualsZero(int initialPoints)
        {
            // Arrange
            var player = new TennisPlayer("SpongeBob", initialPoints, 0);

            // Act
            player.IncreaseGamesAndResetPoints();

            // Assert
            Assert.Equal(0, player.Points);
        }
    }
}
