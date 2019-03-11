using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using RFI.WordsTrainer.Services.Exceptions;
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
            if (!Directory.Exists(_wordsFilesDirectory))
            {
                throw new WordsRepositoryNotAvailableException($"Directory '{_wordsFilesDirectory}' doesn't exist.");
            }

            var files = Directory.GetFiles(_wordsFilesDirectory, "*.xml");
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
            if (string.IsNullOrEmpty(wordSet?.Name))
            {
                throw new InvalidWordsSetException("WordSet name is not specified.");
            }

            var filePath = Path.Combine(_wordsFilesDirectory, wordSet.Name + ".xml");
            if (!File.Exists(filePath))
            {
                throw new InvalidWordsSetException($"WordSet '{filePath}' doesn't exist.");
            }

            return GetWordsFromFile(filePath);
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