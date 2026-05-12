using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    public class Game
    {
        private string wordToGuess;
        private char[] guessedWord;
        private List<char> guessedLetters;
        private int maxTries = 6;
        private int triesLeft;

        public Game(string word)
        {
            wordToGuess = word.ToLower();
            guessedWord = new string('_', wordToGuess.Length).ToCharArray();
            guessedLetters = new List<char>();
            triesLeft = maxTries;
        }

        public bool MakeGuess(char letter)
        {
            letter = char.ToLower(letter);

            if (guessedLetters.Contains(letter))
            {
                Console.WriteLine($"\n⚠️  You've already guessed '{letter}'. Try a different letter!");
                System.Threading.Thread.Sleep(1500);
                return false;
            }

            guessedLetters.Add(letter);

            if (wordToGuess.Contains(letter))
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == letter)
                    {
                        guessedWord[i] = letter;
                    }
                }
                Console.WriteLine($"\n✅ Great! '{letter}' is in the word!");
                System.Threading.Thread.Sleep(1200);
                return true;
            }
            else
            {
                triesLeft--;
                Console.WriteLine($"\n❌ Wrong! '{letter}' is not in the word.");
                System.Threading.Thread.Sleep(1200);
                return false;
            }
        }

        public bool IsWordGuessed() => wordToGuess == new string(guessedWord);

        public bool IsGameOver() => triesLeft <= 0 || IsWordGuessed();

        public void DisplayGameStatus()
        {
            DisplayHangman();
            Console.WriteLine($"\n  Word: {string.Join(" ", guessedWord)}");
            Console.WriteLine($"  Guessed letters: {(guessedLetters.Count > 0 ? string.Join(", ", guessedLetters) : "None")}");
            Console.WriteLine($"  Tries left: {triesLeft}");
        }

        private void DisplayHangman()
        {
            string[] stages = new[]
            {
                "\n  ╔════════════════╗\n  ║                ║\n  ║                ║\n  ║                ║\n  ║                ║\n  ║                ║\n  ║\n═══════════════════",
                "\n  ╔════════════════╗\n  ║                ║\n  ║              😶 ║\n  ║                ║\n  ║                ║\n  ║                ║\n  ║\n═══════════════════",
                "\n  ╔════════════════╗\n  ║                ║\n  ║              😐 ║\n  ║              │  ║\n  ║                ║\n  ║                ║\n  ║\n═══════════════════",
                "\n  ╔════════════════╗\n  ║                ║\n  ║              😐 ║\n  ║             ╱│  ║\n  ║                ║\n  ║                ║\n  ║\n═══════════════════",
                "\n  ╔════════════════╗\n  ║                ║\n  ║              😐 ║\n  ║             ╱│╲ ║\n  ║                ║\n  ║                ║\n  ║\n═══════════════════",
                "\n  ╔════════════════╗\n  ║                ║\n  ║              😟 ║\n  ║             ╱│╲ ║\n  ║             ╱   ║\n  ║                ║\n  ║\n═══════════════════",
                "\n  ╔════════════════╗\n  ║                ║\n  ║              😵 ║\n  ║             ╱│╲ ║\n  ║             ╱ ╲ ║\n  ║                ║\n  ║\n═══════════════════"
            };
            Console.WriteLine(stages[maxTries - triesLeft]);
        }
    }
}
