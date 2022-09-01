namespace Tennis.Tests.Common
{
    internal static class ScoreAdder
    {
        public static void AddScores(ITennisGame game, int player1Score, int player2Score)
        {
            for (var i = 0; i < player1Score; i++)
            {
                game.WonPoint(PlayerId.First);
            }

            for (var i = 0; i < player2Score; i++)
            {
                game.WonPoint(PlayerId.Second);
            }
        }
    }
}
