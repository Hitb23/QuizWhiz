using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DataLayer.Models
{
    public class ResetPassword
    {
        [Key]
        public int ResetId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime TokenExpiry { get; set; }

        [Required]
        public bool IsResetSuccess { get; set; } = false;

        // Navigation properties
        public User User { get; set; }
    }
}
