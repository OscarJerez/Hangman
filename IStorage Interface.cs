using Hangman;
using System.ComponentModel.DataAnnotations;

namespace Hangman
{
    public interface IStorage
    {
        string ReadData();
        string ReadData(string difficulty);
        void WriteData(string data);
    }
}
