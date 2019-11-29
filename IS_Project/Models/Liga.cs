using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Liga
    {
        public Liga()
        {
            LigonioVisitas = new HashSet<LigonioVisitas>();
        }

        public int LilgaId { get; set; }
        public string Pavadinimas { get; set; }
        public string Simptomai { get; set; }
        public int IprastaTrukmeD { get; set; }

        public virtual ICollection<LigonioVisitas> LigonioVisitas { get; set; }
    }
}
