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
    public class LeadersData : ILeadersData
    {
        private readonly EmployeeContext _context;

        public LeadersData(EmployeeContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Adding another email to leader
        /// </summary>
        /// <param name="id">Leader Id</param>
        /// <param name="emailAddress">New emial adress</param>
        public void AddEmail(int id, string emailAddress)
        {
            var email = new Email()
            {
                EmailAddress = emailAddress
            };
            _context.Leaders.Single(x => x.Id == id).EmailAdressess.Add(email);
            _context.SaveChanges();
        }
        /// <summary>
        /// Add new leader
        /// </summary>
        /// <param name="firstName">Leader`s firstname</param>
        /// <param name="lastName">Leader`s lastname</param>
        /// <param name="email">Leader`s email</param>
        public async Task AddNewLeader(string firstName, string lastName, string email)
        {
            var _email = new Email()
            {
                EmailAddress = email
            };
            var newLider = new Leader()
            {
                FirstName = firstName,
                LastName = lastName
            };
            newLider.EmailAdressess.Add(_email);
            await _context.Leaders.AddAsync(newLider);
            _context.SaveChanges();
        }
        //TODO: Change db structure to allow deleting liders
        public void DeleteLeader(int id)
        {
            //_context.Liders.Remove(GetLiderById(id));
            //_context.SaveChanges();
        }
        /// <summary>
        /// Getting all leaders from database
        /// </summary>
        /// <returns>IEnumerable<LeaderModel></returns>
        public IEnumerable<LeaderModel> GetAllLeaders()
        {
            var tac = new TypeAdapterConfig()
                .NewConfig<Leader, LeaderModel>()
                .Map(dest => dest.Id, source => source.Id)
                .Map(dest => dest.FirstName, source => source.FirstName)
                .Map(dest => dest.LastName, source => source.LastName)
                .Map(dest => dest.Email, source => source.EmailAdressess.FirstOrDefault(new Email() { EmailAddress = "" }).EmailAddress)
                .Map(dest => dest.Employees, source => source.Employees)
                .Config;
            
            return _context.Leaders.Include(x => x.EmailAdressess).Include(x => x.Employees).Adapt<IEnumerable<LeaderModel>>(tac);
        }
        /// <summary>
        /// Getting leader with given id
        /// </summary>
        /// <param name="id">Lider`s id</param>
        /// <returns>Lider model</returns>
        public Leader GetLiderById(int id)
        {
            return _context.Leaders.Single(x => x.Id == id);
        }
        /// <summary>
        /// Assigning an employee to a leader.
        /// </summary>
        /// <param name="employeeId">Employee`s id</param>
        /// <param name="leaderId">Leader id</param>
        public void AddEmployeeToLeader(int employeeId, int leaderId)
        {
            var employee = _context.Employees.Single(x => x.Id == employeeId);
            _context.Leaders.Single(x => x.Id == leaderId).Employees.Add(employee);
            _context.SaveChanges();
        }
    }
}
