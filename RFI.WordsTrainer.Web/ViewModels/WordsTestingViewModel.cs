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
    public class WordsTestingViewModel : MasterPageViewModel
    {
        private readonly IWordsService _wordsService;

        [FromQuery(QueryParameterNames.WordsSet)]
        public string WordsSet { get; set; }

        public WordsTestingViewModel(IWordsService wordsService)
        {
            _wordsService = wordsService;
        }

        public override Task Load()
        {
            return base.Load();
        }
    }
}
