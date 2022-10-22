using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalAssignment.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required,RegularExpression("^[0-9]{10}$")]
        public string ContactNumber { get; set; }
    }
}