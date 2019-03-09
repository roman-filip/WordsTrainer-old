using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFI.WordsTrainer.Services.Services;
using RFI.WordsTrainer.Services.Services.Impl.FileWords;

namespace RFI.WordsTrainer.Services.Tests
{
    [TestClass]
    public class FileWordsServiceTest
    {
        [TestMethod]
        public void LoadFileTest()
        {
            IWordsService wordsService = new FileWordsService();
            var words = wordsService.GetAllWords();

            Assert.IsNotNull(words);
        }

        [TestMethod]
        public void AddWordTest()
        {
            IWordsService wordsService = new FileWordsService();

            Assert.ThrowsException<NotImplementedException>(() => wordsService.AddWord(null));
        }
    }
}
