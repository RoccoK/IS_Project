using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Project.Models
{
    public class User
    {
        [DisplayName("E-paštas")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "Neįvestas e-paštas")]
        public string epastas { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Neįvestas slaptažodis")]
        public string Password { get; set; }


    }
}