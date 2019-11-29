using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Daktaras
    {
        public Daktaras()
        {
            DaktarasKabinetas = new HashSet<DaktarasKabinetas>();
            Registracija = new HashSet<Registracija>();
            UzimtumoTvarkarastis = new HashSet<UzimtumoTvarkarastis>();
        }

        public int DaktarasId { get; set; }
        public DateTime PradetaDirbti { get; set; }
        public DateTime? BaigtaDirbti { get; set; }
        public int Busena { get; set; }
        public int Specializacija { get; set; }

        public virtual Vartotojas DaktarasNavigation { get; set; }
        public virtual ICollection<DaktarasKabinetas> DaktarasKabinetas { get; set; }
        public virtual ICollection<Registracija> Registracija { get; set; }
        public virtual ICollection<UzimtumoTvarkarastis> UzimtumoTvarkarastis { get; set; }
    }
}
