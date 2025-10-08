using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI_WebApi.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(30, MinimumLength =3)]
        public string Name { get; set; }
        public string Department { get; set; }
        [Required, RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]
        public string MobileNo { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
