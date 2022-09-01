using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly IScorePresenter scorePresenter;
        private readonly Player player1;
        private readonly Player player2;

        public TennisGame1(
            IScorePresenter scorePresenter,
            Player player1,
            Player player2)
        {
            this.scorePresenter = scorePresenter;
            this.player1 = player1;
            this.player2 = player2;
        }

        public void WonPoint(PlayerId playerId)
        {
            var scoringPlayer = (playerId == PlayerId.First) ? player1 : player2;
            var otherPlayer = (playerId == PlayerId.First) ? player2 : player1;
            
            scoringPlayer.IncreasePoints();

            if (IsScoreComplex(scoringPlayer.Points, otherPlayer.Points))
            {
                if (IsScoreDifferenceGreaterThanOne(scoringPlayer.Points, otherPlayer.Points))
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
            return scorePresenter.GetPointScore(player1, player2);
        }

        public string GetGameScore()
        {
            return scorePresenter.GetGameScore(player1, player2);
        }

        private bool IsScoreComplex(int points1, int points2) => points1 + points2 >= 6;

        private bool IsScoreDifferenceGreaterThanOne(int points1, int points2) =>  Math.Abs(points1 - points2) > 1;
    }
}
