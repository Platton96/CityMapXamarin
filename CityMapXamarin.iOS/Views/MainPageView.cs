using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CityMapXamarin.Core.ViewModels;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace Blank.Views
{
    public  class MainPageView : MvxViewController<MainPageViewModel>
    {
        private UIButton _mapButton;
        private UIView _mainView;
        private UILabel _helloLabel;
        public MainPageView() 
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitComponents();
            ApplyBindings();

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
        private void InitComponents()
        {
            _mainView = new UIView(View.Bounds);
            _mainView.BackgroundColor = UIColor.White;
            View.AddSubview(_mainView);

            _helloLabel = new UILabel(new CGRect(View.Frame.Width-90, 80, 80, 80));
            _mainView.AddSubview(_helloLabel);

            _mapButton = new UIButton(new CGRect(0,150,300,300));
            _mapButton.BackgroundColor = UIColor.Green;
            _mapButton.TitleLabel.TextColor = UIColor.Red;
            _mapButton.Title(UIControlState.Normal);
            _mapButton.TitleLabel.Text = "hgfgfghgf";
            _mapButton.SetTitle("hello world", UIControlState.Normal);

            _mainView.AddSubview(_mapButton);
        }

        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<MainPageView, MainPageViewModel>();
           bindingSet.Bind(_helloLabel).For(b => b.Text).To(vm => vm.Hello);
            bindingSet.Apply();
        }
    }
}