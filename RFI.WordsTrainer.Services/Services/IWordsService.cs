using System.Collections.Generic;
using RFI.WordsTrainer.Services.Entities;

namespace RFI.WordsTrainer.Services.Services
{
    public interface IWordsService
    {
        List<Word> GetAllWords();
    }
}






// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class words
{

    private wordsWord wordField;

    /// <remarks/>
    public wordsWord word
    {
        get
        {
            return this.wordField;
        }
        set
        {
            this.wordField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class wordsWord
{

    private string originalField;

    private string[] translationsField;

    /// <remarks/>
    public string original
    {
        get
        {
            return this.originalField;
        }
        set
        {
            this.originalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("translation", IsNullable = false)]
    public string[] translations
    {
        get
        {
            return this.translationsField;
        }
        set
        {
            this.translationsField = value;
        }
    }
}

