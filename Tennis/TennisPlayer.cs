namespace Tennis
{
    public class TennisPlayer
    {
        public TennisPlayer(string name, int initialScore)
        {
            Name = name;
            Score = initialScore;
        }

        public void IncreaseScore()
        {
            Score++;
        }

        public string Name { get; }
        public int Score { get; private set; }
    }
}
