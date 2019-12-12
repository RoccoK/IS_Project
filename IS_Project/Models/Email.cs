using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IS_Project.Models
{
    public partial class Email
    {
        [Required, Display(Name = "Gavėjo paštas"), EmailAddress]
        public string ToEmail { get; set; }
        [Required, Display(Name = "Žinutė")]
        public string Message { get; set; }
    }
}
