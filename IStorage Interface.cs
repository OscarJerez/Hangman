using Hangman;
using System.ComponentModel.DataAnnotations;

namespace Hangman
{
    public interface IStorage
    {
        string ReadData();
        void WriteData(string data);
    }
}

