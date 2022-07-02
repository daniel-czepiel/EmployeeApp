using EmployeeApp.Library.Helpers;
using EmployeeApp.Library.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace WPF.ViewModels
{
    public class LidersViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ILidersData _liders;

        public IMvxCommand MenuWindow { get; set; }
        public IMvxCommand ShowEmployeesWindow { get; set; }
        public IMvxCommand AddEmployeeWindow { get; set; }
        public IMvxCommand ShowLidersWindow { get; set; }
        public IMvxCommand AddLiderWindow { get; set; }
        public IMvxCommand AddEmployeeToLiderWindow { get; set; }
        public LidersViewModel(IMvxNavigationService navigationService, ILidersData liders)
        {
            _navigationService = navigationService;
            _liders = liders;
            MenuWindow = new MvxCommand(GetMenu);
            ShowEmployeesWindow = new MvxCommand(GetShowEmployee);
            AddEmployeeWindow = new MvxCommand(GetAddEmployee);
            ShowLidersWindow = new MvxCommand(GetShowLiders);
            AddLiderWindow = new MvxCommand(GetAddLider);
            Liders = new ObservableCollection<LiderModel>(_liders.GetAllLiders());
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
        private ObservableCollection<LiderModel> liders;

        public ObservableCollection<LiderModel> Liders
        {
            get { return liders; }
            set { SetProperty(ref liders, value); }
        }

    }
}
