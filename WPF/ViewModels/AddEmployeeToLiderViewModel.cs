using EmployeeApp.Library.Helpers;
using EmployeeApp.Library.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class AddEmployeeToLiderViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ILidersData _lidersData;
        private readonly IEmployeesData _employeesData;

        public IMvxCommand MenuWindow { get; set; }
        public IMvxCommand ShowEmployeesWindow { get; set; }
        public IMvxCommand AddEmployeeWindow { get; set; }
        public IMvxCommand ShowLidersWindow { get; set; }
        public IMvxCommand AddLiderWindow { get; set; }
        public IMvxCommand AddEmployeeToLiderWindow { get; set; }
        public IMvxCommand AddETL { get; set; }
        public AddEmployeeToLiderViewModel(IMvxNavigationService navigationService,
            ILidersData lidersData, IEmployeesData employeesData)
        {
            _navigationService = navigationService;
            _lidersData = lidersData;
            _employeesData = employeesData;
            MenuWindow = new MvxCommand(GetMenu);
            ShowEmployeesWindow = new MvxCommand(GetShowEmployee);
            AddEmployeeWindow = new MvxCommand(GetAddEmployee);
            ShowLidersWindow = new MvxCommand(GetShowLiders);
            AddLiderWindow = new MvxCommand(GetAddLider);
            AddEmployeeToLiderWindow = new MvxCommand(GetAddEmployeeToLiderWindow);
            Employees = new ObservableCollection<int>(_employeesData.GetAllEmployees().Select(x => x.Id));
            Liders = new ObservableCollection<int>(_lidersData.GetAllLiders().Select(x => x.Id));
            AddETL = new MvxCommand(Add);
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
        private ObservableCollection<int> _employees = new ObservableCollection<int>();
        public ObservableCollection<int> Employees
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
        private ObservableCollection<int> liders;

        public ObservableCollection<int> Liders
        {
            get { return liders; }
            set { SetProperty(ref liders, value); }
        }

        private int selectedEmployeeId = -1;

        public int SelectedEmployeeId
        {
            get { return selectedEmployeeId; }
            set 
            {
                selectedEmployeeId = value;
                RaisePropertyChanged(() => CanAdd);
            }
        }

        private int selectedLiderId = -1;

        public int SelectedLiderId
        {
            get { return selectedLiderId; }
            set 
            {
                selectedLiderId = value;
                RaisePropertyChanged(() => CanAdd);
            }
        }
        public bool CanAdd => SelectedEmployeeId != -1 && SelectedLiderId != -1;
        public void Add()
        {
            _lidersData.AddEmployeeToLider(SelectedEmployeeId, SelectedLiderId);
        }
    }
}
