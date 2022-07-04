using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Data.Models
{
    public class Email : IEmail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }
    }
}
