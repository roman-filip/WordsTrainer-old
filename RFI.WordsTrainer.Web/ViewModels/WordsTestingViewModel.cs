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

        [Bind(Direction.ServerToClient)] // This property cannot be changed by the user, it is only set on the server side. There is no need to transfer it from the client to the server.
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
                var words = _wordsService.GetWordsFromSet(new WordSet { Name = WordsSet });
                var random = new Random();

                RandomWord = words[random.Next(words.Count)];
            }
        }

        public void ShowTranslations()
        {
            TranslationsVisible = true;
        }
    }
}
