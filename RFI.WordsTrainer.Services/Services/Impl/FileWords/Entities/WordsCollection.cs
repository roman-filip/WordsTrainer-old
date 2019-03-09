using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RFI.WordsTrainer.Services.Services.Impl.FileWords.Entities
{
    [Serializable]
    [XmlType("words")]
    public class WordsCollection
    {
        [XmlElement("word")]
        public List<Word> Words { get; set; }
    }
}