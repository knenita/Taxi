﻿using Prism;
using Prism.Ioc;
using Syncfusion.Licensing;
using Taxi.Common.Services;
using Taxi.Prism.ViewModels;
using Taxi.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Taxi.Prism
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MjE3OTMwQDMxMzcyZTM0MmUzMENNRCtsQ2Q0RTN2ZlpLakliVFZlb3V0b2hYNkduL1N2V041bU1ObnVXZmM9");
          
            InitializeComponent();

            await NavigationService.NavigateAsync("/TaxiMasterDetailPage/NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IGeolocatorService, GeolocatorService>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<TaxiMasterDetailPage, TaxiMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<TaxiHistoryPage, TaxiHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<GroupPage, GroupPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<ReportPage, ReportPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}