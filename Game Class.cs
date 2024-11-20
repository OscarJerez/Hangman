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
                Console.WriteLine("You've already guessed that letter.");
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
                return true;
            }
            else
            {
                triesLeft--;
                Console.WriteLine($"Wrong guess! Tries left: {triesLeft}");
                return false;
            }
        }

        public bool IsWordGuessed() => wordToGuess == new string(guessedWord);

        public void DisplayWord() => Console.WriteLine(string.Join(" ", guessedWord));

        public bool IsGameOver() => triesLeft <= 0 || IsWordGuessed();

        public void DisplayGameStatus()
        {
            Console.WriteLine($"Word: {string.Join(" ", guessedWord)}");
            Console.WriteLine($"Tries left: {triesLeft}");
        }
    }
}