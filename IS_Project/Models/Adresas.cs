using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Adresas
    {
        public int AdresasId { get; set; }
        public string Miestas { get; set; }
        public string Gatve { get; set; }
        public int NamoNr { get; set; }
        public int PastoKodas { get; set; }

        public virtual Vartotojas AdresasNavigation { get; set; }
    }
}
