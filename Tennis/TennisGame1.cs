using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score = 0;
        private int player2Score = 0;

        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Score++;
            else
                player2Score++;
        }

        public string GetScore()
        {
            if (player1Score < 4 && player2Score < 4 && (player1Score + player2Score) < 6)
            {
                return SimpleScore(player1Score, player2Score);
            }

            return ScoreWhenAnyPlayerHasAtLeastFourPoints(player1Score, player2Score);
        }

        private string SimpleScore(int player1Score, int player2Score)
        {
            var scoreDescription1 = ScoreDescriptor.GetScoreDescription(player1Score);
            var scoreDescription2 = (player1Score == player2Score) ? "All" : ScoreDescriptor.GetScoreDescription(player2Score);
            return $"{scoreDescription1}-{scoreDescription2}";
        }

        private string ScoreWhenAnyPlayerHasAtLeastFourPoints(int player1Score, int player2Score)
        {
            if (player1Score == player2Score)
            {
                return "Deuce";
            }

            var scoreDifference = player1Score - player2Score;
            var outcome = (Math.Abs(scoreDifference) > 1) ? "Win for" : "Advantage";
            var leadPlayer = (scoreDifference > 0) ? "player1" : "player2";
            return $"{outcome} {leadPlayer}";
        }
    }
}
