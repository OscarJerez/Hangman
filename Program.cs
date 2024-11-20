namespace Hangman
{
    public class Program
    {
        static void Main(string[] args)
        {

            {
                try
                {
                    IStorage storage = new JsonStorage("word.json");
                    string wordToGuess = storage.ReadData();

                    if (string.IsNullOrEmpty(wordToGuess))
                    {
                        Console.WriteLine("Error: Unable to read word.");
                        return;
                    }

                    var game = new Game(wordToGuess);
                    var validator = new UserInputValidator();

                    Console.WriteLine("Welcome to Hangman!");

                    while (!game.IsGameOver())
                    {
                        game.DisplayGameStatus();

                        Console.Write("Enter your guess: ");
                        string input = Console.ReadLine()!;

                        if (input == "exit")
                        {
                            break;
                        }

                        var validationResult = validator.Validate(input);
                        if (!validationResult.IsValid)
                        {
                            Console.WriteLine("Invalid input: " + string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
                            continue;
                        }

                        game.MakeGuess(input[0]);
                    }

                    if (game.IsWordGuessed())
                    {
                        Console.WriteLine("Congratulations! You've guessed the word.");
                    }
                    else
                    {
                        Console.WriteLine("Game over! The word was: " + wordToGuess);
                    }

                    // Optionally save the game state to JSON (if you want)
                    storage.WriteData(wordToGuess);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

    }
}

