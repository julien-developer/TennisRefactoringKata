using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private TennisPlayer player1;
        private TennisPlayer player2;

        public TennisGame1(TennisPlayer player1, TennisPlayer player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void WonPoint(PlayerId playerId)
        {
            var scoringPlayer = (playerId == PlayerId.First) ? player1 : player2;
            var otherPlayer = (playerId == PlayerId.First) ? player2 : player1;
            
            scoringPlayer.IncreasePoints();

            if ((scoringPlayer.Points + otherPlayer.Points) >= 6)
            {
                if (Math.Abs(player1.Points - player2.Points) > 1)
                {
                    scoringPlayer.IncreaseGamesAndResetPoints();
                    otherPlayer.ResetPoints();
                }
            }
            else if (scoringPlayer.Points == 4)
            {
                scoringPlayer.IncreaseGamesAndResetPoints();
                otherPlayer.ResetPoints();
            }
        }

        public string GetPointScore()
        {
            if (player1.Points < 4 && player2.Points < 4 && (player1.Points + player2.Points) < 6)
            {
                return SimpleScore(player1.Points, player2.Points);
            }

            return ScoreWhenAnyPlayerHasAtLeastFourPoints(player1.Points, player2.Points);
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

        public string GetGameScore()
        {
            return $"{player1.Name} {player1.Games} - {player2.Games} {player2.Name}";
        }
    }
}
