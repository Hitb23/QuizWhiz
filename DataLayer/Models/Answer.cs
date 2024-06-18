using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DataLayer.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        [ForeignKey("QuestionId")]
        public required int QuestionId { get; set; }
      

        [Required]
        public required string AnswerText { get; set; }

        public Question Question { get; set; }

    }
}
