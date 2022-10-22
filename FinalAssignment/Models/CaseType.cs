using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalAssignment.Models
{
    public class CaseType
    {
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        public string description { get; set; }
    }
}