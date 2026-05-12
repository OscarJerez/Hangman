using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Hangman
{
    public class JsonStorage : IStorage
    {
        private readonly string _filePath;
        private Dictionary<string, List<string>> _wordsByDifficulty;

        public JsonStorage(string filePath)
        {
            _filePath = filePath;
            LoadWords();
        }

        public string ReadData(string difficulty = "easy")
        {
            try
            {
                if (_wordsByDifficulty.ContainsKey(difficulty) && _wordsByDifficulty[difficulty].Count > 0)
                {
                    Random rand = new Random();
                    return _wordsByDifficulty[difficulty][rand.Next(_wordsByDifficulty[difficulty].Count)];
                }
                return "hangman"; // Default fallback
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data: {ex.Message}");
                return null!;
            }
        }

        public string ReadData()
        {
            return ReadData("easy");
        }

        public void WriteData(string data)
        {
            // Not used for current session, but kept for interface compliance
        }

        private void LoadWords()
        {
            _wordsByDifficulty = new Dictionary<string, List<string>>
            {
                { "easy", new List<string>() },
                { "medium", new List<string>() },
                { "hard", new List<string>() }
            };

            try
            {
                if (File.Exists(_filePath))
                {
                    var lines = File.ReadAllLines(_filePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            string word = parts[0].Trim().ToLower();
                            string difficulty = parts[1].Trim().ToLower();

                            if (_wordsByDifficulty.ContainsKey(difficulty))
                            {
                                _wordsByDifficulty[difficulty].Add(word);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading words: {ex.Message}");
            }
        }
    }
}
