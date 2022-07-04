namespace EmployeeApp.Data.Models
{
    public class Leader : PersonBase
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Email> EmailAdressess { get; set; } = new List<Email>();
    }
}
