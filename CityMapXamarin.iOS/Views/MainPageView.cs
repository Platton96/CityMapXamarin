using Blank.Views.CollectionSource;
using CityMapXamarin.Core.ViewModels;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace Blank.Views
{
    public class MainPageView : MvxViewController<MainPageViewModel>
    {
        private UIButton _mapButton;
        private UIView _mainView;
        private UICollectionView _collectionView;
        private CitiesCollectionSource _citiesCollectionSource;

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
            InitMapButton();
            InitCollectionView();

        }

        private void InitMapButton()
        {
            _mapButton = new UIButton(new CGRect(0, 80, 120, 60));
            _mapButton.BackgroundColor = UIColor.Gray;
            _mapButton.SetTitle("Map",UIControlState.Normal);
            _mapButton.TitleLabel.Text = "Map";
            _mainView.AddSubview(_mapButton);
        }

        private void InitCollectionView()
        {
            var layout = new UICollectionViewFlowLayout()
            {
                ItemSize = new CGSize((float)UIScreen.MainScreen.Bounds.Size.Width / 2.0f, (float)UIScreen.MainScreen.Bounds.Size.Width / 2.0f),
                SectionInset = new UIEdgeInsets(0, 0, 0, 0),
                ScrollDirection = UICollectionViewScrollDirection.Vertical,
                MinimumInteritemSpacing = 0,
                MinimumLineSpacing = 0
            };
            _collectionView = new UICollectionView(new CGRect(0, _mapButton.Frame.Bottom + 10, _mainView.Frame.Width, _mainView.Frame.Height - _mapButton.Frame.Bottom - 20), layout);
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
            bindingSet.Bind(_citiesCollectionSource).For(b => b.SelectionChangedCommand).To(vm => vm.NavigateToCityCommand);
            bindingSet.Apply();
        }
    }
}