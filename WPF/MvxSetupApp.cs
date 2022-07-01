using EmployeeApp.Data.DataAccess;
using EmployeeApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using WPF.ViewModels;

namespace WPF.Core
{
    public class MvxSetupApp : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<DbContext>(() => new EmployeeContext());

            RegisterAppStart<ShallViewModel>();
        }
    }
}
