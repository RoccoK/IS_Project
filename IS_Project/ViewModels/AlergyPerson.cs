using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IS_Project.ViewModels
{
    public class AlergyPerson
    {
        [DisplayName("Vardas")]
        public string Vardas { get; set; }
        [DisplayName("Pavarde")]
        public string Pavarde { get; set; }
        [DisplayName("Vaistas")]
        public string Vaistas { get; set; }
        public string Tikrinimas { get; set; }
    }
}