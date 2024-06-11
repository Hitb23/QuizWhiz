using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace server.DataLayer.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        // Foreign key
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        // Navigation properties
      
        public UserRole Role { get; set; }

        public ICollection<ResetPassword> ResetPasswords { get; set; }
        public Contestant Contestant { get; set; }
        public Admin Admin { get; set; }
    }
}
