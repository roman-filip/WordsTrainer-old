using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using RFI.WordsTrainer.Services.Services;
using RFI.WordsTrainer.Web.Views;
using RFI.WordsTrainer.Web.Views.Constants;

namespace RFI.WordsTrainer.Web.ViewModels
{
    public class WordsSetsViewModel : MasterPageViewModel
    {
        private readonly IWordsService _wordsService;

        public List<WordSet> WordsSets { get; set; }

        public WordSet SelectedWordsSet { get; set; }

        public WordsSetsViewModel(IWordsService wordsService)
        {
            _wordsService = wordsService;
        }

        public override async Task Load()
        {
            await base.Load();

            WordsSets = new List<WordSet>(_wordsService.GetAllWordsSets());
            //SelectedWordsSet = WordsSets.FirstOrDefault();
        }

        public void StartTesting()
        {
            Context.RedirectToRoute(ViewNames.WordsTesting,
                query: new Dictionary<string, string> { { QueryParameterNames.WordsSet, SelectedWordsSet?.Name ?? string.Empty } });
        }
    }
}
