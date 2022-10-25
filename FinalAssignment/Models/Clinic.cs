using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        [NotMapped]
        [Display(Name = "Rating")]
        public decimal AvgRating { get; set; } = 0;

        public List<Rating> Ratings { get; set; }
    }
}