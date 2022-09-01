using System;
using Xunit;

namespace Tennis.Tests.Unit
{
    public class ScoreDescriptorTests
    {
        [Theory]
        [InlineData(0, "Love")]
        [InlineData(1, "Fifteen")]
        [InlineData(2, "Thirty")]
        [InlineData(3, "Forty")]
        public void GetScoreDescritpion_ValidScore_ReturnsValidDescription(int score, string scoreDescription)
        {
            var actualScoreDescription = ScoreDescriptor.GetScoreDescription(score);
            Assert.Equal(scoreDescription, actualScoreDescription);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(4)]
        [InlineData(10)]
        public void GetScoreDescription_InvalidScore_ThrowsAnException(int score)
        {
            Assert.Throws<ArgumentException>(() => ScoreDescriptor.GetScoreDescription(score));
        }
    }
}
