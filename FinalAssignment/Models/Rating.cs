using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalAssignment.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        [Required]
        [Range(0, 5)]
        public int Rate { get; set; }
        public string Comment { get; set; }
    }
}