using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IS_Project.ViewModels
{
    public class User
    {
        public int id { get; set; }
        [DisplayName("Vardas")]
        public string Vardas { get; set; }

        [DisplayName("Pavarde")]
        public string Pavarde { get; set; }

        [DisplayName("Pastas")]
        public string Pastas { get; set; }

        [DisplayName("Telefonas")]
        public string Telefonas { get; set; }

        [DisplayName("Miestas")]
        public string Miestas { get; set; }

        [DisplayName("Gatve")]
        public string Gatve { get; set; }

        [DisplayName("Namas")]
        public string Namas { get; set; }

        [DisplayName("PastoKodas")]
        public string PastoKodas { get; set; }

        [DisplayName("GimimoData")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GimimoData { get; set; }

    }
}