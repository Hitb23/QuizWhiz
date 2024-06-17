using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DataLayer.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Column(TypeName = "character varying")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[a-z])(?=.*\W).{8,15}$", ErrorMessage = "Please enter strong password")]
        public required string Password { get; set; }

        [Column(TypeName = "character varying")]
        [Compare("Password")]
        public required string ConfirmPassword { get; set; }
    }
}
