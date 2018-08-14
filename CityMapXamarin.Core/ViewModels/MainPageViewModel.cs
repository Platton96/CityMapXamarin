﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CityMapXamarin.Core.Infrastructure;
using CityMapXamarin.Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace CityMapXamarin.Core.ViewModels
{
    public class MainPageViewModel : MvxViewModel
    {
        private readonly INavigationManager _navigationManager;
        private readonly ICitiesService _citiesService;

        private ObservableCollection<CityModel> _cities;

        public IMvxCommand NavigateToCityCommand => new MvxAsyncCommand<CityModel>(DoNavigateToCityAsync);
        public IMvxCommand NavigateToCityMapCommand => new MvxAsyncCommand(DoNavigateToCityMapAsync);


        public ObservableCollection<CityModel> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }

        public MainPageViewModel(ICitiesService citiesService, INavigationManager navigationManager)
        {
            _citiesService = citiesService;
            _navigationManager = navigationManager;
        }

        public override async void ViewCreated()
        {
            base.ViewCreated();
            Cities = new ObservableCollection<CityModel>(await _citiesService.GetCitiesAsync());

        }

        private async Task DoNavigateToCityAsync(CityModel city)
        {
            await _navigationManager.NavigateToCityAsync(city);
        }

        private async Task DoNavigateToCityMapAsync()
        {
            await _navigationManager.NavigateToCityMapAsync(_cities);
        }
    }
}