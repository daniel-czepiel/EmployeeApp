using EmployeeApp.Data.DataAccess;
using EmployeeApp.Data.Models;
using EmployeeApp.Library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Library.Helpers
{
    public class EmployeesData : IEmployeesData
    {
        private readonly EmployeeContext _context;

        public EmployeesData(EmployeeContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="firstName">Employee`s firstname</param>
        /// <param name="lastName">Employee`s lastname</param>
        /// <param name="email">Employee`s email</param>
        /// <param name="position">Employee`s position</param>
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
        /// <summary>
        /// Getting all employees from database
        /// </summary>
        /// <returns>IEnumerable<EmployeeModel></returns>
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {

            var tac = new TypeAdapterConfig()
                .NewConfig<Employee, EmployeeModel>()
                .Map(dest => dest.Id, source => source.Id)
                .Map(dest => dest.FirstName, source => source.FirstName)
                .Map(dest => dest.LastName, source => source.LastName)
                .Map(dest => dest.Email, source => source.EmailAdressess.FirstOrDefault(new Email() { EmailAddress = "" }).EmailAddress)
                .Map(dest => dest.Position, source => source.Position)
                .Config;

            return _context.Employees.Include(x => x.EmailAdressess).Adapt<IEnumerable<EmployeeModel>>(tac);
        }
        /// <summary>
        /// Adding another email to employee
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <param name="emailAddress">New emial adress</param>
        public void AddEmail(int id, string emailAddress)
        {
            var email = new Email()
            {
                EmailAddress = emailAddress
            };
            _context.Employees.Single(x => x.Id == id).EmailAdressess.Add(email);
            _context.SaveChanges();
        }
        /// <summary>
        /// Getting employee with given id
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>Employee</returns>
        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Single(x => x.Id == id);
        }
        public void DeleteEmployee(int id)
        {
            _context.Employees.Remove(GetEmployeeById(id));
            _context.SaveChanges();
        }
    }
}
