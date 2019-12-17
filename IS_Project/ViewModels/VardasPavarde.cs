using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IS_Project.ViewModels
{
    public class VardasPavarde
    {

        [DisplayName("Vardas")]
        public string Vardas { get; set; }
        [DisplayName("Pavarde")]
        public string Pavarde { get; set; }
    }
}