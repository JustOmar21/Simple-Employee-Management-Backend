using Backend.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class EmployeeUpdate
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression(@"^[A-Za-z][A-Za-z\'\- ]{2,}$", ErrorMessage = "A name consist of letters only and at least 3 letters")]
        public string Name { get; set; }
        [EnumDataType(typeof(Role), ErrorMessage = "Role can only be Manager (0), Developer (1) or Designer (2)")]
        public Role Role { get; set; }
        [EnumDataType(typeof(Gender), ErrorMessage = "Gender can only be Male (0) or Female (1)")]
        public Gender Gender { get; set; }
        public bool Is1stAppointment { get; set; }
        public string? Notes { get; set; }
    }
}
