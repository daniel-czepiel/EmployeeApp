using EmployeeApp.Data.DataAccess;
using EmployeeApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Library.Helpers
{
    public class EmployeesData : IEmployeesData
    {
        private readonly EmployeeContext _context;

        public EmployeesData(EmployeeContext context)
        {
            _context = context;
        }
        public async Task AddNewEmployee(string firstName, string lastName, string email, string position)
        {
            var _email = new Email()
            {
                EmailAddress = email
            };
            var newEmployee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Position = position
            };
            newEmployee.EmailAdressess.Add(_email);
            await _context.Employees.AddAsync(newEmployee);
            _context.SaveChanges();
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }
        public void AddEmail(int id, string emailAddress)
        {
            var email = new Email()
            {
                EmailAddress = emailAddress
            };
            _context.Employees.Single(x => x.Id == id).EmailAdressess.Add(email);
            _context.SaveChanges();
        }
    }
}
