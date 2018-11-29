using System.Collections.Generic;
using System.Xml.Serialization;

namespace RFI.WordsTrainer.Services.Entities
{
    [XmlType("word")]
    public partial class Word
    {
        [XmlElement("original")]
        public string original { get; set; }

        /// <remarks/>
        //public List<string> translations { get; set; }
    }
}
