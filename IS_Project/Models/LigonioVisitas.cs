using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace IS_Project.Models
{
    public partial class LigonioVisitas
    {
        [DisplayName("Visito ID")]
        public int LigonioVisitasId { get; set; }

        [DisplayName("Data nuo")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNuo { get; set; }
        [DisplayName("Data iki")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataIki { get; set; }
        [DisplayName("Komentarai")]
        public string Komentarai { get; set; }
        public int FkLigaId { get; set; }
        public int FkPalataId { get; set; }
        public int FkPacientasId { get; set; }

        [DisplayName("Liga")]
        public virtual Liga FkLiga { get; set; }
        [DisplayName("Pacientas")]
        public virtual Pacientas FkPacientas { get; set; }
        [DisplayName("Palata")]
        public virtual Palata FkPalata { get; set; }

        [NotMapped]
        public IList<SelectListItem> NamesList { get; set; }
        [NotMapped]
        public IList<SelectListItem> IllList { get; set; }
        [NotMapped]
        public IList<SelectListItem> RoomList { get; set; }
    }
}
