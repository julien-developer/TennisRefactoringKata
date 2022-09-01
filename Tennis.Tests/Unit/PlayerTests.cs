using Xunit;

namespace Tennis.Tests.Unit
{
    public class PlayerTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(3, 4)]
        [InlineData(6, 7)]
        public void Points_WhenIncreasePoints_ReturnsExpectedValue(int initialPoints, int expectedPoints)
        {
            // Arrange
            var player = new Player("SpongeBob", initialPoints, 0);

            // Act
            player.IncreasePoints();
            var actual = player.Points;

            // Assert
            Assert.Equal(expectedPoints, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 0)]
        public void Games_WhenIncreasePoints_RemainsTheSame(int initialPoints, int initialGames)
        {
            // Arrange
            var player = new Player("SpongeBob", initialPoints, initialGames);

            // Act
            player.IncreasePoints();
            var actual = player.Games;

            // Assert
            Assert.Equal(initialGames, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(9)]
        public void Points_WhenIncreaseGamesAndResetPoints_EqualsZero(int initialPoints)
        {
            // Arrange
            var player = new Player("SpongeBob", initialPoints, 0);

            // Act
            player.IncreaseGamesAndResetPoints();
            var actual = player.Points;

            // Assert
            Assert.Equal(0, actual);
        }
    }
}
