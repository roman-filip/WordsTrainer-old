using System;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using RFI.WordsTrainer.Services.Entities;
using RFI.WordsTrainer.Services.Services;
using RFI.WordsTrainer.Web.Views.Constants;

namespace RFI.WordsTrainer.Web.ViewModels
{
    public class WordsTestingViewModel : MasterPageViewModel
    {
        private readonly IWordsService _wordsService;

        [FromQuery(QueryParameterNames.WordsSet)]
        public string WordsSet { get; set; }

        public Word RandomWord { get; set; }

        public bool TranslationsVisible { get; set; }

        public WordsTestingViewModel(IWordsService wordsService)
        {
            _wordsService = wordsService;
        }

        public override async Task Load()
        {
            await base.Load();

            if (RandomWord == null)
            {
                SetRandomWord();
            }
        }

        public void ShowTranslations()
        {
            TranslationsVisible = true;
        }

        public void ShowNextWord()
        {
            SetRandomWord();
            TranslationsVisible = false;
        }

        private void SetRandomWord()
        {
            var words = _wordsService.GetWordsFromSet(new WordSet { Name = WordsSet });
            var random = new Random();

            RandomWord = words[random.Next(words.Count)];
        }
    }
}
