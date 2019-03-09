using System.Collections.Generic;

namespace RFI.WordsTrainer.Services.Entities
{
    public class Word
    {
        public string Original { get; set; }

        public List<string> Translations { get; set; }
    }
}
