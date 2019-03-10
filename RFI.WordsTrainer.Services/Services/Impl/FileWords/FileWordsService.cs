using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using RFI.WordsTrainer.Services.Services.Impl.FileWords.Entities;
using Word = RFI.WordsTrainer.Services.Entities.Word;

namespace RFI.WordsTrainer.Services.Services.Impl.FileWords
{
    public class FileWordsService : IWordsService
    {
        private readonly string _wordsFilesDirectory;

        public FileWordsService(string wordsFilesDirectory)
        {
            _wordsFilesDirectory = wordsFilesDirectory;
        }

        public List<WordSet> GetAllWordsSets()
        {
            var files = Directory.GetFiles(_wordsFilesDirectory);
            var wordSets = files
                .OrderBy(f => f)
                .Select(f => new WordSet { Name = Path.GetFileNameWithoutExtension(f) })
                .ToList();

            return wordSets;
        }

        public List<Word> GetAllWords()
        {
            var words = new List<Word>();
            foreach (var filePath in Directory.GetFiles(_wordsFilesDirectory))
            {
                words.AddRange(GetWordsFromFile(filePath));
            }

            return words;
        }

        public List<Word> GetWordsFromSet(WordSet wordSet)
        {
            throw new NotImplementedException();
        }

        public void AddWord(WordSet wordSet, Word word)
        {
            throw new NotImplementedException();
        }

        private static List<Word> GetWordsFromFile(string filePath)
        {
            var serializer = new XmlSerializer(typeof(WordsCollection));
            using (Stream reader = new FileStream(filePath, FileMode.Open))
            {
                var wordsFromFile = (WordsCollection)serializer.Deserialize(reader);
                return ConvertWords(wordsFromFile);
            }
        }

        private static List<Word> ConvertWords(WordsCollection wordsFromFile)
        {
            // TODO - use AutoMapper
            var words = new List<Word>();
            wordsFromFile.Words.ForEach(w => words.Add(new Word
            {
                Original = w.Original,
                Translations = new List<string>(w.Translations)
            }));
            return words;
        }
    }
}