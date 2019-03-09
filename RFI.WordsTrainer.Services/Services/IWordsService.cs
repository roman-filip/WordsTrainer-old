using System.Collections.Generic;
using RFI.WordsTrainer.Services.Entities;

namespace RFI.WordsTrainer.Services.Services
{
    public interface IWordsService
    {
        List<Word> GetAllWords();
        void AddWord(Word word);
    }
}
