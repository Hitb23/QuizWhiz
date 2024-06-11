﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DataLayer.Models
{
    public class Contestant
    {
        [Key]
        public int ContestantId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string Profession { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        [MaxLength(10)]
        public string NameAbbreviation { get; set; }

        [Required]
        public bool IsNotificationEnabled { get; set; }

        // Navigation properties
       
        public User User { get; set; }
    }
}