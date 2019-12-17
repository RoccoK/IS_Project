using IS_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Project.ViewModels
{
    public class RegistrationView
    {
        public int RegistracijaId { get; set; }
        public DateTime PateikimoData { get; set; }
        public int Busena { get; set; }
        [DisplayName("Kviesta greitoji:")]
        public sbyte KviestaGreitoji { get; set; }
        public int FkPacientasId { get; set; }
        [DisplayName("Daktaras:")]
        [Required]
        public int FkDaktarasId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Vizito data:")]
        [Required]
        public DateTime VisitoData { get; set; }

        public virtual Daktaras FkDaktaras { get; set; }
        public virtual Pacientas FkPacientas { get; set; }
        public IList<SelectListItem> DaktarasList { get; set; }
        public IList<SelectListItem> PacientasList { get; set; }
    }
}