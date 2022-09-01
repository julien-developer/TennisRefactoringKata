using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private TennisPlayer player1;
        private TennisPlayer player2;

        public TennisGame1(string player1Name, string player2Name)
        {
            player1 = new TennisPlayer(player1Name, 0);
            player2 = new TennisPlayer(player2Name, 0);
        }

        public void WonPoint(PlayerId playerId)
        {
            if (playerId == PlayerId.First)
                player1.IncreaseScore();
            else
                player2.IncreaseScore();
        }

        public string GetScore()
        {
            if (player1.Score < 4 && player2.Score < 4 && (player1.Score + player2.Score) < 6)
            {
                return SimpleScore(player1.Score, player2.Score);
            }

            return ScoreWhenAnyPlayerHasAtLeastFourPoints(player1.Score, player2.Score);
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
            var leadPlayer = (scoreDifference > 0) ? player1.Name : player2.Name;
            return $"{outcome} {leadPlayer}";
        }
    }
}
