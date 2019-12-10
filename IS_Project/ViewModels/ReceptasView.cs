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
    public class ReceptasView
    {
        [DisplayName("Vaistas")]
        public int FkVaistasId { get; set; }
        [DisplayName("Pacientas")]
        public int FkPacientasId { get; set; }
        [DisplayName("Data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        [DisplayName("Laikas")]
        public TimeSpan? Laikas { get; set; }
        [DisplayName("Recepto nr.")]
        public int ReceptoNr { get; set; }

        public virtual Pacientas FkPacientas { get; set; }
        public virtual Vaistas FkVaistas { get; set; }

        public IList<SelectListItem> VaistasList { get; set; }
        public IList<SelectListItem> PacientasList { get; set; }
    }
}