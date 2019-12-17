using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IS_Project.Models
{
    public partial class Palata
    {
        public Palata()
        {
            LigonioVisitas = new HashSet<LigonioVisitas>();
        }

        [DisplayName("Palatos ID")]
        public int PalataId { get; set; }
        [DisplayName("Palatos numers")]
        public int PalataNr { get; set; }
        [DisplayName("Vietų skaičius")]
        public int VietuSkaicius { get; set; }
        [DisplayName("Užimtų vietų skaičius")]
        public int UzimtaVietu { get; set; }

        public virtual ICollection<LigonioVisitas> LigonioVisitas { get; set; }
    }
}
