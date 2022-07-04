using EmployeeApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Data.DataAccess
{
    public class EmployeeContext : DbContext
    {
        //public EmployeeContext(DbContextOptions options) : base(options) { }
        public DbSet<PersonBase> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> EmailAdressess { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFEmployeeAppDB;Trusted_Connection=True;");
        }
    }
}
