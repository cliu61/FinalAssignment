using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalAssignment.Models
{
    public class Booking
    {
        [Required]
        public int CaseId { get; set; }
        public Case Case { get; set; }
        [Required]
        public String UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}