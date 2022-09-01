using System;
using Xunit;

namespace Tennis.Tests.Unit
{
    public class ScorePresenterTests
    {
        private readonly IScorePresenter _scorePresenter;

        public ScorePresenterTests()
        {
            _scorePresenter = new ScorePresenter();
        }

        [Theory]
        [ClassData(typeof(ScorePresenterTestsData))]
        public void GetPointScore_ReturnsExpectedScore(int score1, int score2, string name1, string name2, string expected)
        {
            // Arrange
            var player1 = new Player(name1, score1, 0);
            var player2 = new Player(name2, score2, 0);

            // Act
            var actual = _scorePresenter.GetPointScore(player1, player2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, 0)]
        [InlineData(0, 4)]
        [InlineData(4, 2)]
        [InlineData(2, 4)]
        [InlineData(4, 6)]
        [InlineData(6, 4)]
        [InlineData(16, 14)]
        [InlineData(14, 16)]
        public void GetPointScore_WhenScoresAreInvalid_ThrowsArgumentException(int score1, int score2)
        {
            // Arrange
            var player1 = new Player("player1", score1, 0);
            var player2 = new Player("player2", score2, 0);

            // Assert
            Assert.Throws<ArgumentException>(() => _scorePresenter.GetPointScore(player1, player2));
        }

        [Theory]
        [InlineData(1, 0, "Sponge", "Bob", "Sponge 1 - 0 Bob")]
        [InlineData(0, 1, "Sponge", "Bob", "Sponge 0 - 1 Bob")]
        public void GetGameScore_ReturnsExpectedValue(int gamesWon1, int gamesWon2, string name1, string name2, string expceted)
        {
            // Arrange
            var player1 = new Player(name1, 0, gamesWon1);
            var player2 = new Player(name2, 0, gamesWon2);

            // Act
            var actual = _scorePresenter.GetGameScore(player1, player2);

            // Assert
            Assert.Equal(expceted, actual);
        }
    }
}
