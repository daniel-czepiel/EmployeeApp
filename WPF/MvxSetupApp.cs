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
            Mvx.IoCProvider.RegisterType<EmployeeContext>(() => new EmployeeContext());

            //Checking if database was created
            var context = Mvx.IoCProvider.Create<EmployeeContext>();
            context.Database.EnsureCreated();

            RegisterAppStart<ShallViewModel>();
        }
    }
}
