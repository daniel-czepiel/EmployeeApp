using EmployeeApp.Library.Helpers;
using EmployeeApp.Library.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace WPF.ViewModels
{
    public class EmployeesViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IEmployeesData _data;

        public IMvxCommand MenuWindow { get; set; }
        public IMvxCommand ShowEmployeesWindow { get; set; }
        public IMvxCommand AddEmployeeWindow { get; set; }
        public IMvxCommand DeleteEmployeeCommand { get; set; }
        public IMvxCommand ShowLidersWindow { get; set; }
        public IMvxCommand AddLiderWindow { get; set; }
        public IMvxCommand AddEmployeeToLiderWindow { get; set; }
        public EmployeesViewModel(IMvxNavigationService navigationService, IEmployeesData data)
        {
            _navigationService = navigationService;
            _data = data;
            MenuWindow = new MvxCommand(GetMenu);
            ShowEmployeesWindow = new MvxCommand(GetShowEmployee);
            AddEmployeeWindow = new MvxCommand(GetAddEmployee);
            DeleteEmployeeCommand = new MvxCommand(DeleteEmployee);
            Employees = new ObservableCollection<EmployeeModel>(_data.GetAllEmployees());
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

        private ObservableCollection<EmployeeModel> _employees = new ObservableCollection<EmployeeModel>();
        public ObservableCollection<EmployeeModel> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                SetProperty(ref _employees, value);
            }
        }

        private EmployeeModel employeeToDell;

        public EmployeeModel EmployeeToDell
        {
            get { return employeeToDell; }
            set 
            {
                employeeToDell = value;
                RaisePropertyChanged(() => CanDelete);
            }
        }
        public bool CanDelete => EmployeeToDell != null;
        public void DeleteEmployee()
        {
            _data.DeleteEmployee(EmployeeToDell.Id);
            Employees = new ObservableCollection<EmployeeModel>(_data.GetAllEmployees());
            RaisePropertyChanged(() => Employees);
        }

    }
}
