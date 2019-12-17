using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Project.Models
{
    public partial class UzimtumoTvarkarastis
    {
        [DisplayName("Id:")]
        public int UzimtumoTvarkarastisId { get; set; }
        [DisplayName("Trukmė:")]
        public int TrukmeMin { get; set; }       
        public int FkDaktarasId { get; set; }
        [DisplayName("Daktaras")]
        public virtual Daktaras FkDaktaras { get; set; }
    }
}
