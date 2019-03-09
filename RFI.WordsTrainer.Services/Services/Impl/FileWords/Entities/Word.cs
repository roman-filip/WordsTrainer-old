using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RFI.WordsTrainer.Services.Services.Impl.FileWords.Entities
{
    [Serializable]
    public class Word
    {
        [XmlElement("original")]
        public string Original { get; set; }

        [XmlArray("translations")]
        [XmlArrayItem("translation", IsNullable = false)]
        public List<string> Translations { get; set; }
    }
}