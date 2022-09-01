using System;

namespace Tennis
{
    public interface IScorePresenter
    {
        string GetGameScore(Player player1, Player player2);
        string GetPointScore(Player player1, Player player2);
    }

    public class ScorePresenter : IScorePresenter
    {
        public string GetPointScore(Player player1, Player player2)
        {
            if (player1.Points + player2.Points >= 6 && Math.Abs(player1.Points - player2.Points) < 2)
            {
                return ComplexScore(player1, player2);
            }

            if (player1.Points < 4 && player2.Points < 4)
            {
                return SimpleScore(player1.Points, player2.Points);
            }

            throw new ArgumentException($"Invalid score. First player: {player1.Points}. Second player: {player2.Points}.");
        }

        public string GetGameScore(Player player1, Player player2)
        {
            return $"{player1.Name} {player1.Games} - {player2.Games} {player2.Name}";
        }

        private string SimpleScore(int player1Score, int player2Score)
        {
            var scoreDescription1 = ScoreDescriptor.GetScoreDescription(player1Score);
            var scoreDescription2 = (player1Score == player2Score) ? "All" : ScoreDescriptor.GetScoreDescription(player2Score);
            return $"{scoreDescription1}-{scoreDescription2}";
        }

        private string ComplexScore(Player player1, Player player2)
        {
            if (player1.Points == player2.Points)
            {
                return "Deuce";
            }

            var leadPlayer = (player1.Points - player2.Points > 0) ? player1.Name : player2.Name;
            return $"Advantage {leadPlayer}";
        }
    }
}