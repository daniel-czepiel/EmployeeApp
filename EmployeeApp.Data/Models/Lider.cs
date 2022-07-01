namespace EmployeeApp.Data.Models
{
    public class Lider : PersonBase
    {
        public List<Email> Employees { get; set; } = new List<Email>();
        public List<Email> EmailAdressess { get; set; } = new List<Email>();
    }
}
