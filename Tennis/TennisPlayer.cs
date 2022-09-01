namespace Tennis
{
    public class TennisPlayer
    {
        public TennisPlayer(string name, int initialPoints, int initialGames)
        {
            Name = name;
            Points = initialPoints;
            Games = initialGames;
        }

        public void IncreasePoints()
        {
            Points++;
        }

        public void ResetPoints()
        {
            Points = 0;
        }

        public void IncreaseGamesAndResetPoints()
        {
            Games++;
            ResetPoints();
        }

        public string Name { get; }
        public int Points { get; private set; }
        public int Games { get; private set; }
    }
}
