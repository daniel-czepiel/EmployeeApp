﻿using EmployeeApp.Data.Models;
using EmployeeApp.Library.Models;

namespace EmployeeApp.Library.Helpers
{
    public interface IEmployeesData
    {
        void AddEmail(int id, string emailAddress);
        Task AddNewEmployee(string firstName, string lastName, string email, string position);
        IEnumerable<EmployeeModel> GetAllEmployees();
    }
}