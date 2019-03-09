using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFI.WordsTrainer.Services.Services;
using RFI.WordsTrainer.Services.Services.Impl.FileWords;

namespace RFI.WordsTrainer.Services.Tests
{
    [TestClass]
    public class FileWordsServiceTest
    {
        private readonly IWordsService _wordsService = new FileWordsService(@".\TestData\EN_seznam_words.xml");

        [TestMethod]
        public void LoadAllWordsTest()
        {
            var words = _wordsService.GetAllWords();

            Assert.IsNotNull(words);
            Assert.AreEqual(2, words.Count);

            Assert.AreEqual("abandoned", words[0].Original);
            Assert.AreEqual(3, words[0].Translations.Count);
            Assert.AreEqual("opuštěný", words[0].Translations[0]);
            Assert.AreEqual("prázdný", words[0].Translations[1]);
            Assert.AreEqual("nepoužívaný", words[0].Translations[2]);

            Assert.AreEqual("abs", words[1].Original);
            Assert.AreEqual(1, words[1].Translations.Count);
            Assert.AreEqual("břišní svaly", words[1].Translations[0]);
        }

        [TestMethod]
        public void AddWordTest()
        {
            Assert.ThrowsException<NotImplementedException>(() => _wordsService.AddWord(null));
        }
    }
}
