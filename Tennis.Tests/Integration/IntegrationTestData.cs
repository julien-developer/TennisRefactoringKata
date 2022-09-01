using System.Collections;
using System.Collections.Generic;

namespace Tennis.Tests.Integration
{
    internal class IntegrationTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new int[] { 0,0,0 }, 0, 0, "Forty-Love" },
            new object[] { new int[] { 0,0,0,0 }, 1, 0, "Love-All" },
            new object[] { new int[] { 0,0,0,1,1,1 }, 0, 0, "Deuce" },
            new object[] { new int[] { 0,0,0,1,1,1,0 }, 0, 0, "Advantage player1" },
            new object[] { new int[] { 0,0,0,1,1,1,1 }, 0, 0, "Advantage player2" },
            new object[] { new int[] { 0,0,0,1,1,1,0,1 }, 0, 0, "Deuce" },
            new object[] { new int[] { 0,0,0,1,1,1,0,1,0,0 }, 1, 0, "Love-All" },
            new object[] { new int[] { 0,0,0,1,1,1,0,1,1,1 }, 0, 1, "Love-All" }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
