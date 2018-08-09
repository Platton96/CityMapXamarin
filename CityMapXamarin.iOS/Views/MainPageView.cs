using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Views.TableSource;
using CityMapXamarin.Core.Models;
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
        private UICollectionView _collectionView;
        private CitiesCollectionSource _citiesCollectionSource;
        public MainPageView() 
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitComponents();
            ApplyBindings();
        }
        private void InitComponents()
        {
            _mainView = new UIView(View.Bounds);
            _mainView.BackgroundColor = UIColor.White;
            View.AddSubview(_mainView);


            _mapButton = new UIButton(new CGRect(0,80,120,60));
            _mapButton.BackgroundColor = UIColor.Green;
            _mainView.AddSubview(_mapButton);

            var layout = new UICollectionViewFlowLayout();
         //   layout.SectionInset = new UIEdgeInsets(50, 50, 100, 100);
            _collectionView = new UICollectionView(new CGRect(0, _mapButton.Frame.Bottom+20, _mainView.Frame.Width, _mainView.Frame.Height - _mapButton.Frame.Bottom - 20), layout);
            _mainView.AddSubview(_collectionView);
            _citiesCollectionSource = new CitiesCollectionSource(_collectionView);
            _collectionView.Source = _citiesCollectionSource;
            _collectionView.BackgroundColor = UIColor.White;

        }

        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<MainPageView, MainPageViewModel>();
            bindingSet.Bind(_mapButton).To(vm => vm.NavigateToCityMapCommand);
            bindingSet.Bind(_citiesCollectionSource).For(b => b.ItemsSource).To(vm => vm.Cities);
            bindingSet.Apply();
        }
    }
}