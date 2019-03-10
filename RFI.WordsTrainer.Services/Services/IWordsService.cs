using System.Collections.Generic;
using RFI.WordsTrainer.Services.Entities;

namespace RFI.WordsTrainer.Services.Services
{
    public interface IWordsService
    {
        List<WordSet> GetAllWordsSets();
        List<Word> GetAllWords();
        List<Word> GetWordsFromSet(WordSet wordSet);
        void AddWord(WordSet wordSet, Word word);
    }
}
