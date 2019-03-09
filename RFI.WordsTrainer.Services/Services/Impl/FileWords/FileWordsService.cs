using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using RFI.WordsTrainer.Services.Services.Impl.FileWords.Entities;

namespace RFI.WordsTrainer.Services.Services.Impl.FileWords
{
    public class FileWordsService : IWordsService
    {
        public List<WordsTrainer.Services.Entities.Word> GetAllWords()
        {
            var serializer = new XmlSerializer(typeof(WordsCollection));
            using (Stream reader =
                new FileStream(@"C:\_GitHub\WordsTrainer\RFI.WordsTrainer.Services\Words\EN_seznam_words.xml",
                    FileMode.Open))
            {
                var words = (WordsCollection)serializer.Deserialize(reader);
            }

            return new List<WordsTrainer.Services.Entities.Word>();
        }

        public void AddWord(WordsTrainer.Services.Entities.Word word)
        {
            throw new NotImplementedException();
        }
    }
}