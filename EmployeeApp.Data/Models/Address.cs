using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Data.Models
{
    public class Address : IAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? StreetAddress { get; set; }
        [Required]
        [MaxLength(50)]
        public string? City { get; set; }
        [Required]
        [MaxLength(50)]
        public string? State { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? ZipCode { get; set; }
    }
}
