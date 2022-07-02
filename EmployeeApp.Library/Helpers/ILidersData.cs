using EmployeeApp.Data.Models;
using EmployeeApp.Library.Models;

namespace EmployeeApp.Library.Helpers
{
    public interface ILidersData
    {
        void AddEmail(int id, string emailAddress);
        void AddEmployeeToLider(int employeeId, int liderId);
        Task AddNewLider(string firstName, string lastName, string email);
        void DeleteLider(int id);
        IEnumerable<LiderModel> GetAllLiders();
        Lider GetLiderById(int id);
    }
}