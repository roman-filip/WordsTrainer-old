using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using RFI.WordsTrainer.Services.Services.Impl.FileWords.Entities;

namespace RFI.WordsTrainer.Services.Services.Impl.FileWords
{
    public class FileWordsService : IWordsService
    {
        public string FilePath { get; set; }

        public FileWordsService(string filePath)
        {
            FilePath = filePath;
        }

        public List<WordsTrainer.Services.Entities.Word> GetAllWords()
        {
            var serializer = new XmlSerializer(typeof(WordsCollection));
            using (Stream reader = new FileStream(FilePath, FileMode.Open))
            {
                var wordsFromFile = (WordsCollection)serializer.Deserialize(reader);
                return ConvertWords(wordsFromFile);
            }
        }

        public void AddWord(WordsTrainer.Services.Entities.Word word)
        {
            throw new NotImplementedException();
        }

        private static List<WordsTrainer.Services.Entities.Word> ConvertWords(WordsCollection wordsFromFile)
        {
            // TODO - use AutoMapper
            var words = new List<WordsTrainer.Services.Entities.Word>();
            wordsFromFile.Words.ForEach(w => words.Add(new WordsTrainer.Services.Entities.Word
            {
                Original = w.Original,
                Translations = new List<string>(w.Translations)
            }));
            return words;
        }
    }
}