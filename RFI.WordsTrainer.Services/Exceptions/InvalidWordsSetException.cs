using System;

namespace RFI.WordsTrainer.Services.Exceptions
{
    public class InvalidWordsSetException : Exception
    {
        public InvalidWordsSetException(string message) : base(message)
        { }
    }
}