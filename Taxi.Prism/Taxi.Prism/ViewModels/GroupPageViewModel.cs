using Prism.Navigation;
using Taxi.Prism.Helpers;

namespace Taxi.Prism.ViewModels
{
    public class GroupPageViewModel : ViewModelBase
    {
        public GroupPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.AdminMyUserGroup;
        }
    }
}