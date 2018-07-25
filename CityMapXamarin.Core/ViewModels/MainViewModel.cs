using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace CityMapXamarin.Core.ViewModels
{
    public class MainViewModel :  BaseViewModel
    {
        public MainViewModel()
        {
        }

        private void Prepare()
        {
            // This is the first method to be called after construction
        }

        public override Task Initialize()
        {
            // Async initialization, YEY!

            return base.Initialize();
        }

        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);

        private void ResetText()
        {
            Text = "Hello xomarin";
        }

        private string _text = "Hello MvvmCross";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}
