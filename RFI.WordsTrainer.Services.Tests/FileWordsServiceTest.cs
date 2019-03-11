using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFI.WordsTrainer.Services.Exceptions;
using RFI.WordsTrainer.Services.Services;
using RFI.WordsTrainer.Services.Services.Impl.FileWords;

namespace RFI.WordsTrainer.Services.Tests
{
    [TestClass]
    public class FileWordsServiceTest
    {
        private readonly IWordsService _wordsService = new FileWordsService(@".\TestData");

        [TestMethod]
        public void GetAllWordsSetsTest_NotExistingDir()
        {
            IWordsService wordsService = new FileWordsService(@".\NonExistingDir");
            Assert.ThrowsException<WordsRepositoryNotAvailableException>(() => wordsService.GetAllWordsSets());
        }

        [TestMethod]
        public void GetAllWordsSetsTest_EmptyDir()
        {
            IWordsService wordsService = new FileWordsService(@".\TestData\EmptyDir");
            var wordSets = wordsService.GetAllWordsSets();

            Assert.IsNotNull(wordSets);
            Assert.AreEqual(0, wordSets.Count);
        }

        [TestMethod]
        public void GetAllWordsSetsTest()
        {
            var wordSets = _wordsService.GetAllWordsSets();

            Assert.IsNotNull(wordSets);
            Assert.AreEqual(2, wordSets.Count);
            Assert.AreEqual("EN_seznam_words", wordSets[0].Name);
            Assert.AreEqual("EN_seznam_words2", wordSets[1].Name);
        }

        [TestMethod]
        public void LoadAllWordsTest()
        {
            var words = _wordsService.GetAllWords();

            Assert.IsNotNull(words);
            Assert.AreEqual(3, words.Count);

            Assert.AreEqual("abandoned", words[0].Original);
            Assert.AreEqual(3, words[0].Translations.Count);
            Assert.AreEqual("opuštěný", words[0].Translations[0]);
            Assert.AreEqual("prázdný", words[0].Translations[1]);
            Assert.AreEqual("nepoužívaný", words[0].Translations[2]);

            Assert.AreEqual("abs", words[1].Original);
            Assert.AreEqual(1, words[1].Translations.Count);
            Assert.AreEqual("břišní svaly", words[1].Translations[0]);

            Assert.AreEqual("youth", words[2].Original);
            Assert.AreEqual(1, words[2].Translations.Count);
            Assert.AreEqual("mládí", words[2].Translations[0]);
        }

        [TestMethod]
        public void GetWordsFromSetTest_EmptySet()
        {
            Assert.ThrowsException<InvalidWordsSetException>(() => _wordsService.GetWordsFromSet(null));
        }

        [TestMethod]
        public void GetWordsFromSetTest_NonExistingSet()
        {
            Assert.ThrowsException<InvalidWordsSetException>(() => _wordsService.GetWordsFromSet(new WordSet { Name = "NON_EXISTING_SET" }));
        }

        [TestMethod]
        public void AddWordTest()
        {
            Assert.ThrowsException<NotImplementedException>(() => _wordsService.AddWord(null, null));
        }
    }
}
