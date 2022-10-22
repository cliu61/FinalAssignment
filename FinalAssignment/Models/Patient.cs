using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalAssignment.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required,MaxLength(30)]
        public string FirstName { get; set; }
        [Required,MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}