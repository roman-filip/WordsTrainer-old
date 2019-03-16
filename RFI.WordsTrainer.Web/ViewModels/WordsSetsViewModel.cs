using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using RFI.WordsTrainer.Services.Services;

namespace RFI.WordsTrainer.Web.ViewModels
{
    public class WordsSetsViewModel : MasterPageViewModel
    {
        private readonly IWordsService _wordsService;

        public string Title { get; set; }

        public List<WordSet> WordsSets { get; set; }

        public WordSet SelectedWordsSet { get; set; }

        public WordsSetsViewModel(IWordsService wordsService)
        {
            Title = "Words trainer";

            _wordsService = wordsService;
        }

        public override async Task Load()
        {
            await base.Load();

            WordsSets = new List<WordSet>(_wordsService.GetAllWordsSets());
        }
    }
}
