using System.Collections;
using System.Collections.Generic;

namespace Tennis.Tests.Unit
{
    internal class ScorePresenterTestsData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {0, 0, "Sponge", "Bob", "Love-All"},
            new object[] {1, 1, "Sponge", "Bob", "Fifteen-All"},
            new object[] {2, 2, "Sponge", "Bob", "Thirty-All"},
            new object[] {3, 3, "Sponge", "Bob", "Deuce"},
            new object[] {4, 4, "Sponge", "Bob", "Deuce"},
            new object[] {5, 5, "Sponge", "Bob", "Deuce"},
            new object[] {1, 0, "Sponge", "Bob", "Fifteen-Love"},
            new object[] {0, 1, "Sponge", "Bob", "Love-Fifteen"},
            new object[] {2, 0, "Sponge", "Bob", "Thirty-Love"},
            new object[] {0, 2, "Sponge", "Bob", "Love-Thirty"},
            new object[] {3, 0, "Sponge", "Bob", "Forty-Love"},
            new object[] {0, 3, "Sponge", "Bob", "Love-Forty"},
            new object[] {2, 1, "Sponge", "Bob", "Thirty-Fifteen"},
            new object[] {1, 2, "Sponge", "Bob", "Fifteen-Thirty"},
            new object[] {3, 1, "Sponge", "Bob", "Forty-Fifteen"},
            new object[] {1, 3, "Sponge", "Bob", "Fifteen-Forty"},
            new object[] {3, 2, "Sponge", "Bob", "Forty-Thirty"},
            new object[] {2, 3, "Sponge", "Bob", "Thirty-Forty"},
            new object[] {4, 3, "Sponge", "Bob", "Advantage Sponge"},
            new object[] {3, 4, "Sponge", "Bob", "Advantage Bob"},
            new object[] {5, 4, "Sponge", "Bob", "Advantage Sponge"},
            new object[] {4, 5, "Sponge", "Bob", "Advantage Bob"},
            new object[] {15, 14, "Sponge", "Bob", "Advantage Sponge"},
            new object[] {14, 15, "Sponge", "Bob", "Advantage Bob" }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}