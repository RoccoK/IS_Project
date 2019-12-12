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
        [Required]
        [DisplayName("Vardas")]
        public string Vardas { get; set; }
        [Required]
        [DisplayName("Pavardė")]
        public string Pavarde { get; set; }
        [Required]
        [DisplayName("Paštas")]
        public string Pastas { get; set; }
        [Required]
        [DisplayName("Telefonas")]
        public string Telefonas { get; set; }
        [Required]
        [DisplayName("Miestas")]
        public string Miestas { get; set; }
        [Required]
        [DisplayName("Gatvė")]
        public string Gatve { get; set; }
        [Required]
        [DisplayName("Namas")]
        public int Namas { get; set; }
        [Required]
        [DisplayName("Pašto kodas")]
        public int PastoKodas { get; set; }
        [Required]
        [DisplayName("Gimimo data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GimimoData { get; set; }
        [Required]
        [DisplayName("Gimimo miestas")]
        public string GimimoMiestas { get; set; }
        [Required]
        [DisplayName("Gimimo ligoninės pavadinimas")]
        public string GimimoLigoninesPav { get; set; }
        [DisplayName("Draudimo nr.")]
        public int DraudimoNr { get; set; }
        [Required]
        [DisplayName("Specializacija")]
        public int Specializacija { get; set; }
        public DateTime PradetaDirbti { get; set; }

    }
}