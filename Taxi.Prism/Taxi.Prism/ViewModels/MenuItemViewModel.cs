using Taxi.Common.Models;
using Prism.Commands;
using Prism.Navigation;

namespace Taxi.Prism.ViewModels
{
    public class MenuItemViewModel : Menu
    {
        private readonly INavigationService _navigationService;//clases que permiten navegar de una pag a otra
        private DelegateCommand _selectMenuCommand;//comando ejecutar accion 

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenuAsync));

        private async void SelectMenuAsync()
        {
            await _navigationService.NavigateAsync($"/TaxiMasterDetailPage/NavigationPage/{PageName}");
        }
    }
}