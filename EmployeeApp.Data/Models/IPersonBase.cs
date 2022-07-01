namespace EmployeeApp.Data.Models
{
    public interface IPersonBase
    {
        int Age { get; set; }
        string? FirstName { get; set; }
        int Id { get; set; }
        string? LastName { get; set; }
    }
}