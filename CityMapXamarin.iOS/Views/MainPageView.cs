using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CityMapXamarin.Core.ViewModels;
using Foundation;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace Blank.Views
{
    public  class MainPageView : MvxViewController<MainPageViewModel>
    {
        public MainPageView() 
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //var set = this.CreateBindingSet<TipView, TipViewModel>();
            //set.Bind(TipLabel).To(vm => vm.Tip);
            //set.Bind(SubTotalTextField).To(vm => vm.SubTotal);
            //set.Bind(GenerositySlider).To(vm => vm.Generosity);
            //set.Apply();

            //View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            //{
            //    this.SubTotalTextField.ResignFirstResponder();
            //}));
        }
    }
}