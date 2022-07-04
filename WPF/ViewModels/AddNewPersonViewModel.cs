using EmployeeApp.Data.DataAccess;
using EmployeeApp.Data.Models;
using EmployeeApp.Library.Helpers;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class AddNewPersonViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IEmployeesData _employeesData;

        public IMvxCommand MenuWindow { get; set; }
        public IMvxCommand ShowEmployeesWindow { get; set; }
        public IMvxCommand AddEmployeeWindow { get; set; }
        public IMvxCommand AddEmployee { get; set; }
        public IMvxCommand ShowLidersWindow { get; set; }
        public IMvxCommand AddLiderWindow { get; set; }
        public IMvxCommand AddEmployeeToLiderWindow { get; set; }
        public AddNewPersonViewModel(IMvxNavigationService navigationService, IEmployeesData employeesData)
        {
            _navigationService = navigationService;
            _employeesData = employeesData;
            MenuWindow = new MvxCommand(GetMenu);
            ShowEmployeesWindow = new MvxCommand(GetShowEmployee);
            AddEmployeeWindow = new MvxCommand(GetAddEmployee);
            AddEmployee = new MvxCommand(AddNewEmployee);
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

        #region Propertys
        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set 
            {
                firstname = value;
                RaisePropertyChanged(() => CanAddPerson);
            }
        }
        private string lastname;
        public string Lastname 
        { 
            get { return lastname; }
            set 
            {
                lastname = value;
                RaisePropertyChanged(() => CanAddPerson);
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }
        private string position;
        public string Position
        {
            get { return position; }
            set
            {
                position = value;
                RaisePropertyChanged(() => CanAddPerson);
            }
        }
        public bool CanAddPerson => Lastname.Length > 2 && Firstname.Length > 2;
        #endregion
        public async void AddNewEmployee()
        {
            await _employeesData.AddNewEmployee(Firstname, Lastname, Email, Position);
        }
    }
}
