using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }
    }
}