using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace WPF.ViewModels
{
    public class ShallViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand MenuWindow { get; set; }
        public IMvxCommand ShowEmployeesWindow { get; set; }
        public IMvxCommand AddEmployeeWindow { get; set; }
        public IMvxCommand ShowLidersWindow { get; set; }
        public IMvxCommand AddLiderWindow { get; set; }
        public IMvxCommand AddEmployeeToLiderWindow { get; set; }
        public ShallViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuWindow = new MvxCommand(GetMenu);
            ShowEmployeesWindow = new MvxCommand(GetShowEmployee);
            AddEmployeeWindow = new MvxCommand(GetAddEmployee);
            ShowLidersWindow = new MvxCommand(GetShowLiders);
            AddLiderWindow = new MvxCommand(GetAddLider);
            AddEmployeeToLiderWindow = new MvxCommand(GetAddEmployeeToLiderWindow);
        }

        #region Menu methods
        public async void GetMenu() =>
            await _navigationService.Navigate<ShallViewModel>();
        public async void GetShowEmployee() =>
            await _navigationService.Navigate<EmployeesViewModel>();
        public async void GetAddEmployee() =>
            await _navigationService.Navigate<AddNewPersonViewModel>();
        public async void GetAddLider() =>
            await _navigationService.Navigate<AddNewLiderViewModel>();
        public async void GetShowLiders() =>
            await _navigationService.Navigate<LidersViewModel>();
        public async void GetAddEmployeeToLiderWindow() =>
            await _navigationService.Navigate<AddEmployeeToLiderViewModel>();
        #endregion
    }
}
