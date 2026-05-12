namespace Hangman
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IStorage storage = new JsonStorage("word.json");
                var validator = new UserInputValidator();
                var gameStats = new GameStats();
                bool playAgain = true;

                Console.OutputEncoding = System.Text.Encoding.UTF8;

                while (playAgain)
                {
                    Console.Clear();
                    DisplayMainMenu(gameStats);

                    Console.Write("\nChoose an option: ");
                    string choice = Console.ReadLine()!.Trim();

                    switch (choice)
                    {
                        case "1":
                            PlayGame(storage, validator, gameStats, "easy");
                            break;
                        case "2":
                            PlayGame(storage, validator, gameStats, "medium");
                            break;
                        case "3":
                            PlayGame(storage, validator, gameStats, "hard");
                            break;
                        case "4":
                            DisplayStats(gameStats);
                            break;
                        case "5":
                            playAgain = false;
                            Console.Clear();
                            Console.WriteLine("\n🎮 Thanks for playing Hangman! Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            System.Threading.Thread.Sleep(1500);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void DisplayMainMenu(GameStats stats)
        {
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║         🎮 HANGMAN GAME 🎮        ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("  1. Play (Easy)");
            Console.WriteLine("  2. Play (Medium)");
            Console.WriteLine("  3. Play (Hard)");
            Console.WriteLine("  4. View Statistics");
            Console.WriteLine("  5. Exit");
            Console.WriteLine();
            Console.WriteLine($"  📊 Stats: {stats.GamesWon}W / {stats.GamesLost}L | Win Rate: {stats.WinRate:F1}%");
        }

        static void DisplayStats(GameStats stats)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║          📊 STATISTICS 📊          ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine($"  Total Games Played: {stats.GamesPlayed}");
            Console.WriteLine($"  Games Won:         {stats.GamesWon}");
            Console.WriteLine($"  Games Lost:        {stats.GamesLost}");
            Console.WriteLine($"  Win Rate:          {stats.WinRate:F1}%");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void PlayGame(IStorage storage, UserInputValidator validator, GameStats stats, string difficulty)
        {
            string wordToGuess = storage.ReadData(difficulty);

            if (string.IsNullOrEmpty(wordToGuess))
            {
                Console.Clear();
                Console.WriteLine("❌ Error: Unable to read word. Please check word.json file.");
                System.Threading.Thread.Sleep(2000);
                return;
            }

            var game = new Game(wordToGuess);
            bool gameWon = false;

            while (!game.IsGameOver())
            {
                Console.Clear();
                game.DisplayGameStatus();

                Console.Write("\nEnter your guess (or 'exit' to quit): ");
                string input = Console.ReadLine()!.Trim().ToLower();

                if (input == "exit")
                {
                    Console.Clear();
                    Console.WriteLine("\n❌ Game abandoned. Returning to menu...");
                    System.Threading.Thread.Sleep(1500);
                    return;
                }

                var validationResult = validator.Validate(input);
                if (!validationResult.IsValid)
                {
                    Console.WriteLine($"\n❌ Invalid input: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
                    System.Threading.Thread.Sleep(1500);
                    continue;
                }

                game.MakeGuess(input[0]);
            }

            Console.Clear();
            gameWon = game.IsWordGuessed();

            if (gameWon)
            {
                game.DisplayGameStatus();
                Console.WriteLine("\n🎉 Congratulations! You've guessed the word correctly! 🎉");
                stats.GamesWon++;
            }
            else
            {
                game.DisplayGameStatus();
                Console.WriteLine($"\n😢 Game Over! The word was: '{wordToGuess}'");
                stats.GamesLost++;
            }

            stats.GamesPlayed++;
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
