using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Project.Models
{
    public partial class Registracija
    {
        [DisplayName("Registracijos ID")]
        public int RegistracijaId { get; set; }
        [DisplayName("Pateikimo data")]
        public DateTime PateikimoData { get; set; }
        [DisplayName("Būsena")]
        public int Busena { get; set; }
        [DisplayName("Kviesta greitoji")]
        public sbyte KviestaGreitoji { get; set; }
        [DisplayName("Paciento ID")]
        public int FkPacientasId { get; set; }
        [DisplayName("Daktaro ID")]
        public int FkDaktarasId { get; set; }
        [DisplayName("Vizito data")]
        public DateTime VisitoData { get; set; }

        [DisplayName("Daktaras")]
        public virtual Daktaras FkDaktaras { get; set; }
        [DisplayName("Pacientas")]
        public virtual Pacientas FkPacientas { get; set; }

        [NotMapped]
        public IList<SelectListItem> ListPat { get; set; }
        [NotMapped]
        public IList<SelectListItem> ListDoc { get; set; }
    }
}
