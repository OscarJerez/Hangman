

namespace Hangman
{

    public class JsonStorage : IStorage
    {
        private readonly string _filePath;

        public JsonStorage(string filePath)
        {
            _filePath = filePath;
        }

        public string ReadData()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    return File.ReadAllText(_filePath);
                }
                else
                {
                    return "hangman"; // Default word if no file exists
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading data: " + ex.Message);
                return null!;
            }
        }

        public void WriteData(string data)
        {
            try
            {
                File.WriteAllText(_filePath, data);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error writing data: " + ex.Message);
            }
        }
    }
}