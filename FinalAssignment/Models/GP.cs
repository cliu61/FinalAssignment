using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalAssignment.Models
{
    public class GP
    {
        [Key]
        public int GPId { get; set; }
        [Required,MaxLength(30)]
        public string FirstName { get; set; }
        [Required, MaxLength(30)]
        public String LastName { get; set; }
        [Required]
        public String Specialist { get; set; }
    }
}