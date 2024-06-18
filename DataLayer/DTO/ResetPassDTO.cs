using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DataLayer.DTO
{
    public class ResetPassDTO
    {
        public required string Token { get; set; }

        [Column(TypeName = "character varying")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[a-z])(?=.*\W).{8,15}$", ErrorMessage = "Please enter strong password")]
        public required string NewPassword { get; set; }

        [Column(TypeName = "character varying")]
        [Compare("NewPassword")]
        public required string ConfirmNewPassword { get; set; }
    }
}
