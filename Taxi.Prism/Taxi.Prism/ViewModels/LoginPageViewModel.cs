using Prism.Navigation;
using Taxi.Prism.Helpers;

namespace Taxi.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            //Title = "Log in";
            Title = Languages.LogIn;
        }
    }
}