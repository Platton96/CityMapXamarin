using Blank.Converters;
using CityMapXamarin.Core.ViewModels;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace Blank.Views
{
    public class CityView : MvxViewController<CityViewModel>
    {
        private UIView _mainView;
        private UIImageView _imageView;
        private UITextView _textView;

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
            InitImageView();
            InitTextView();
        }
        private void InitImageView()
        {
            _imageView = new UIImageView(new CGRect(40, 40, _mainView.Frame.Width-80, (_mainView.Frame.Height-20)/2f));
            _mainView.AddSubview(_imageView);
        }
        private void InitTextView()
        {
            _textView= new UITextView(new CGRect(10, _imageView.Frame.Bottom+10, _mainView.Frame.Width-20, _mainView.Frame.Height - _imageView.Frame.Bottom - 10));
            _textView.Font = UIFont.FromName("HelveticaNeue-Bold", 16f);
            _mainView.AddSubview(_textView);
        }
        private void ApplyBindings()
        {
            var bindingSet = this.CreateBindingSet<CityView, CityViewModel>();
            bindingSet.Bind(_imageView).For(b => b.Image).To(vm => vm.City.FilePath).WithConversion<ImagePathToImageConverter>();
            bindingSet.Bind(_textView).For(b => b.Text).To(vm => vm.City.Description);
            bindingSet.Apply();
        }
    }
}