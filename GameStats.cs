namespace Hangman
{
    public class GameStats
    {
        public int GamesPlayed { get; set; } = 0;
        public int GamesWon { get; set; } = 0;
        public int GamesLost { get; set; } = 0;

        public double WinRate
        {
            get
            {
                if (GamesPlayed == 0) return 0;
                return (GamesWon / (double)GamesPlayed) * 100;
            }
        }
    }
}
