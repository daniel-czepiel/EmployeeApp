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
    public class EmployeesViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand Menu { get; set; }
        public IMvxCommand ShowEmployees { get; set; }
        public IMvxCommand AddEmployee { get; set; }
        public EmployeesViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            Menu = new MvxCommand(GetMenu);
            ShowEmployees = new MvxCommand(GetShowEmployee);
            AddEmployee = new MvxCommand(GetAddEmployee);
        }
        public async void GetMenu() =>
            await _navigationService.Navigate<ShallViewModel>();
        public async void GetShowEmployee() =>
            await _navigationService.Navigate<EmployeesViewModel>();
        public async void GetAddEmployee() =>
            await _navigationService.Navigate<AddNewPersonViewModel>();
    }
}
