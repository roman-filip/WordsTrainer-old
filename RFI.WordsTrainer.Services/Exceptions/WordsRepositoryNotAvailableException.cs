using System;

namespace RFI.WordsTrainer.Services.Exceptions
{
    public class WordsRepositoryNotAvailableException : Exception
    {
        public WordsRepositoryNotAvailableException(string message) : base(message)
        { }
    }
}