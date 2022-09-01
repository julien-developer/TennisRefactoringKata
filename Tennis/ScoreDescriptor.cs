using System;
using System.Collections.Generic;

namespace Tennis
{
    public static class ScoreDescriptor
    {
        private static IDictionary<int, string> scoreDescriptions = new Dictionary<int, string>()
        {
            { 0, "Love" },
            { 1, "Fifteen" },
            { 2, "Thirty" },
            { 3, "Forty" },
        };

        public static string GetScoreDescription(int score)
        {
            if (scoreDescriptions.TryGetValue(score, out var result))
            {
                return result;
            };

            throw new ArgumentException($"Score {score} has no valid description.");
        }
    }
}
