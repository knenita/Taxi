using Prism.Navigation;
using Taxi.Prism.Helpers;

namespace Taxi.Prism.ViewModels
{
    public class ReportPageViewModel : ViewModelBase
    {
        public ReportPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.ReportAnIncident;
        }
    }
}