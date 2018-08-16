using CityMapXamarin.Core.Infrastructure;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;

namespace CityMapXamarin.Core.ViewModels
{
    public class LoginViewModel :  MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;  

        private const string DEFAULT_LOGIN = "123";
        private const string DEFAULT_PASSWORD = "123";
        private  TimeSpan _maxDeferenceAmongLoginTime = new TimeSpan(0, 10, 0);

        private bool _isVisibleErrorMessage;
        private string _email;
        private string _password;
        public IMvxCommand LoginAsyncCommand => new MvxAsyncCommand(DoLoginAsync);
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public bool IsVisibleErrorMessage
        {
            get => _isVisibleErrorMessage;
            set
            {
                _isVisibleErrorMessage = value;
                RaisePropertyChanged(() => IsVisibleErrorMessage);
            }
        }

        public LoginViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public  override async void ViewCreated()
        {
            base.ViewCreated();
            if (IsCanGetMainPage())
            {
                SettingsManager.LastLoginTime = DateTime.Now;
                await _navigationService.Navigate<MainPageViewModel>();
            }

        }

        private async Task DoLoginAsync()
        {
            if (IsCorrectLoginAndPassword())
            {
                SettingsManager.LastLoginTime = DateTime.Now;
                await _navigationService.Navigate<MainPageViewModel>();

            }
            else
            {
                IsVisibleErrorMessage = true;
            }
            
        }
        private bool IsCanGetMainPage()
        {
            return (DateTime.Now - SettingsManager.LastLoginTime).Minutes <= _maxDeferenceAmongLoginTime.Minutes;
        }
        private bool IsCorrectLoginAndPassword()
        {
            return _email == DEFAULT_LOGIN && _password == DEFAULT_PASSWORD;
        }
    }
}
