using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace RFI.WordsTrainer.Web.ViewModels
{
    public class WordsSetsViewModel : MasterPageViewModel
    {
        public string Title { get; set; }

        public WordsSetsViewModel()
        {
            Title = "Words trainer";
        }
    }
}
