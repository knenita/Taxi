﻿using Prism.Commands;
using Prism.Navigation;
using System.Text.RegularExpressions;
using Taxi.Common.Models;
using Taxi.Common.Services;

namespace Taxi.Prism.ViewModels
{
    public class TaxiHistoryPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService; //consume servicios
        private TaxiResponse _taxi;
        private bool _isRunning; //prop privada
        private DelegateCommand _checkPlaqueCommand;//atributo privado

        public TaxiHistoryPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService) 
        {
            _apiService = apiService;
            Title = "Taxi History";
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public TaxiResponse Taxi
        {
            get => _taxi;
            set => SetProperty(ref _taxi, value);//modifcar prop en la view model y que se vea reflejado en la view
        }

        public string Plaque { get; set; }

        //prop de lectura publica 
        public DelegateCommand CheckPlaqueCommand => _checkPlaqueCommand ?? (_checkPlaqueCommand = new DelegateCommand(CheckPlaqueAsync));

        private async void CheckPlaqueAsync()//metodo
        {
            if (string.IsNullOrEmpty(Plaque))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a plaque.",
                    "Accept");
                return;
            }

            Regex regex = new Regex(@"^([A-Za-z]{3}\d{3})$");
            if (!regex.IsMatch(Plaque))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "The plaque must start with three letters and end with three numbers.",
                    "Accept");
                return;
            }

            IsRunning = true;
            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
                return;
            }

            Response response = await _apiService.GetTaxiAsync(Plaque, url, "api", "/Taxis");
            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            } 
            Taxi = (TaxiResponse)response.Result;
        }
    }
}