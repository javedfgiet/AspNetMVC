using System;
using System.ComponentModel.DataAnnotations;
namespace BusinessLayer
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}
