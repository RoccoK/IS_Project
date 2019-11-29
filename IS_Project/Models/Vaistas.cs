using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Vaistas
    {
        public Vaistas()
        {
            KomplikacijosAlergijaVaistas = new HashSet<KomplikacijosAlergijaVaistas>();
            NesuderinamasVaistasFkVaistasId1Navigation = new HashSet<NesuderinamasVaistas>();
            NesuderinamasVaistasFkVaistasId2Navigation = new HashSet<NesuderinamasVaistas>();
            Receptas = new HashSet<Receptas>();
            VaistoVartojimas = new HashSet<VaistoVartojimas>();
        }

        public int VaistasId { get; set; }
        public string Pavadinimas { get; set; }
        public float Kaina { get; set; }

        public virtual ICollection<KomplikacijosAlergijaVaistas> KomplikacijosAlergijaVaistas { get; set; }
        public virtual ICollection<NesuderinamasVaistas> NesuderinamasVaistasFkVaistasId1Navigation { get; set; }
        public virtual ICollection<NesuderinamasVaistas> NesuderinamasVaistasFkVaistasId2Navigation { get; set; }
        public virtual ICollection<Receptas> Receptas { get; set; }
        public virtual ICollection<VaistoVartojimas> VaistoVartojimas { get; set; }
    }
}
