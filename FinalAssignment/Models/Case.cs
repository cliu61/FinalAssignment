using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalAssignment.Models
{
    public class Case
    {
        public int Id { get; set; }
        [Required]
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        [Required]
        public int CaseTypeId { get; set; }
        public CaseType CaseType { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0: dd/MMM/yyyy hh:mm:tt}")]
        public DateTime StartTime { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0: dd/MMM/yyyy hh:mm:tt}")]
        public DateTime EndTime { get; set; }
    }
}