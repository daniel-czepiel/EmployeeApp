namespace EmployeeApp.Data.Models
{
    public interface IPersonBase
    {
        string? FirstName { get; set; }
        int Id { get; set; }
        string? LastName { get; set; }
    }
}