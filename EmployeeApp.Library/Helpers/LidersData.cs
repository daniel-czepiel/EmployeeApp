using EmployeeApp.Data.DataAccess;
using EmployeeApp.Data.Models;
using EmployeeApp.Library.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Library.Helpers
{
    public class LidersData : ILidersData
    {
        private readonly EmployeeContext _context;

        public LidersData(EmployeeContext context)
        {
            _context = context;
        }
        public void AddEmail(int id, string emailAddress)
        {
            var email = new Email()
            {
                EmailAddress = emailAddress
            };
            _context.Liders.Single(x => x.Id == id).EmailAdressess.Add(email);
            _context.SaveChanges();
        }

        public async Task AddNewLider(string firstName, string lastName, string email)
        {
            var _email = new Email()
            {
                EmailAddress = email
            };
            var newLider = new Lider()
            {
                FirstName = firstName,
                LastName = lastName
            };
            newLider.EmailAdressess.Add(_email);
            await _context.Liders.AddAsync(newLider);
            _context.SaveChanges();
        }

        public void DeleteLider(int id)
        {
            _context.Liders.Remove(GetLiderById(id));
            _context.SaveChanges();
        }

        public IEnumerable<LiderModel> GetAllLiders()
        {
            var tac = new TypeAdapterConfig()
                .NewConfig<Lider, LiderModel>()
                .Map(dest => dest.Id, source => source.Id)
                .Map(dest => dest.FirstName, source => source.FirstName)
                .Map(dest => dest.LastName, source => source.LastName)
                .Map(dest => dest.Email, source => source.EmailAdressess.FirstOrDefault(new Email() { EmailAddress = "" }).EmailAddress)
                .Map(dest => dest.Employees, source => source.Employees)
                .Config;

            return _context.Liders.Include(x => x.EmailAdressess).Include(x => x.Employees).Adapt<IEnumerable<LiderModel>>(tac);
        }

        public Lider GetLiderById(int id)
        {
            return _context.Liders.Single(x => x.Id == id);
        }

        public void AddEmployeeToLider(int employeeId, int liderId)
        {
            var employee = _context.Employees.Single(x => x.Id == employeeId);
            _context.Liders.Single(x => x.Id == liderId).Employees.Add(employee);
            _context.SaveChanges();
        }
    }
}
