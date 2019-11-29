using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Alergija
    {
        public Alergija()
        {
            AlergijaPacientas = new HashSet<AlergijaPacientas>();
            KomplikacijosAlergijaVaistas = new HashSet<KomplikacijosAlergijaVaistas>();
        }

        public int AlergijaId { get; set; }
        public string Pavadinimas { get; set; }

        public virtual ICollection<AlergijaPacientas> AlergijaPacientas { get; set; }
        public virtual ICollection<KomplikacijosAlergijaVaistas> KomplikacijosAlergijaVaistas { get; set; }
    }
}
