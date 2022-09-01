namespace Tennis
{
    public interface ITennisGame
    {
        void WonPoint(PlayerId playerId);
        string GetScore();
    }
}

