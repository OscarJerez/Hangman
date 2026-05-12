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
            // Handle file path - check multiple locations
            _filePath = ResolveFilePath(filePath);
            LoadWords();
        }

        private string ResolveFilePath(string filePath)
        {
            // Try 1: Current directory
            if (File.Exists(filePath))
                return filePath;

            // Try 2: Executable directory
            string execPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            if (File.Exists(execPath))
                return execPath;

            // Try 3: Parent directories
            string currentDir = Directory.GetCurrentDirectory();
            string parentPath = Path.Combine(currentDir, filePath);
            if (File.Exists(parentPath))
                return parentPath;

            // If not found, return the original (will create with defaults)
            return filePath;
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
                return "hangman";
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
                        var trimmedLine = line.Trim();
                        if (string.IsNullOrWhiteSpace(trimmedLine))
                            continue;

                        var parts = trimmedLine.Split(':');
                        if (parts.Length == 2)
                        {
                            string word = parts[0].Trim().ToLower();
                            string difficulty = parts[1].Trim().ToLower();

                            if (!string.IsNullOrWhiteSpace(word) && _wordsByDifficulty.ContainsKey(difficulty))
                            {
                                _wordsByDifficulty[difficulty].Add(word);
                            }
                        }
                    }

                    // Debug info
                    Console.WriteLine($"✓ Loaded words - Easy: {_wordsByDifficulty["easy"].Count}, Medium: {_wordsByDifficulty["medium"].Count}, Hard: {_wordsByDifficulty["hard"].Count}");
                }
                else
                {
                    Console.WriteLine($"⚠ Warning: word.json not found at {_filePath}");
                    Console.WriteLine($"Current directory: {Directory.GetCurrentDirectory()}");
                    Console.WriteLine($"Executable directory: {AppDomain.CurrentDomain.BaseDirectory}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading words: {ex.Message}");
            }
        }
    }
}
