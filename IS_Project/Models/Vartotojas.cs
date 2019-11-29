using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Vartotojas
    {
        public Vartotojas()
        {
            Zinute = new HashSet<Zinute>();
        }

        public int VartotojasId { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string Elpastas { get; set; }
        public string TelNr { get; set; }

        public virtual Administratorius Administratorius { get; set; }
        public virtual Adresas Adresas { get; set; }
        public virtual Daktaras Daktaras { get; set; }
        public virtual Pacientas Pacientas { get; set; }
        public virtual ICollection<Zinute> Zinute { get; set; }
    }
}
