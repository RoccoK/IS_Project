using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Palata
    {
        public Palata()
        {
            LigonioVisitas = new HashSet<LigonioVisitas>();
        }

        public int PalataId { get; set; }
        public int PalataNr { get; set; }
        public int VietuSkaicius { get; set; }
        public int UzimtaVietu { get; set; }

        public virtual ICollection<LigonioVisitas> LigonioVisitas { get; set; }
    }
}
