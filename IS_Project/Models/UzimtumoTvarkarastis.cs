using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class UzimtumoTvarkarastis
    {
        public int UzimtumoTvarkarastisId { get; set; }
        public int TrukmeMin { get; set; }
        public int FkDaktarasId { get; set; }

        public virtual Daktaras FkDaktaras { get; set; }
    }
}
