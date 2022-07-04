using EmployeeApp.Data.Models;
using EmployeeApp.Library.Models;

namespace EmployeeApp.Library.Helpers
{
    public interface ILeadersData
    {
        void AddEmail(int id, string emailAddress);
        void AddEmployeeToLeader(int employeeId, int leaderId);
        Task AddNewLeader(string firstName, string lastName, string email);
        void DeleteLeader(int id);
        IEnumerable<LeaderModel> GetAllLeaders();
        Leader GetLiderById(int id);
    }
}