using Prism.Navigation;
using Taxi.Prism.Helpers;

namespace Taxi.Prism.ViewModels
{
    public class ModifyUserPageViewModel : ViewModelBase
    {
        public ModifyUserPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.ModifyUser;
        }
    }
}