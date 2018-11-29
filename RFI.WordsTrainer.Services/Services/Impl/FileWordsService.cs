using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using RFI.WordsTrainer.Services.Entities;

namespace RFI.WordsTrainer.Services.Services.Impl
{
    public class FileWordsService : IWordsService
    {
        public List<Word> GetAllWords()
        {
            var serializer = new XmlSerializer(typeof(words));
            using (Stream reader = new FileStream(@"C:\_GitHub\WordsTrainer\RFI.WordsTrainer.Services\Words\EN_seznam_words.xml", FileMode.Open))
            {
                var a = (words)serializer.Deserialize(reader);
            }




            //var serializer = new XmlSerializer(typeof(List<Word>), new XmlRootAttribute("words"));
            //using (Stream reader = new FileStream(@"C:\_GitHub\WordsTrainer\RFI.WordsTrainer.Services\Words\EN_seznam_words.xml", FileMode.Open))
            //{
            //    var a = (List<Word>)serializer.Deserialize(reader);
            //}

            return null;
        }
    }
}
