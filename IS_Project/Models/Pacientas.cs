using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Pacientas
    {
        public Pacientas()
        {
            AlergijaPacientas = new HashSet<AlergijaPacientas>();
            LigonioVisitas = new HashSet<LigonioVisitas>();
            Receptas = new HashSet<Receptas>();
            Registracija = new HashSet<Registracija>();
            VaistoVartojimas = new HashSet<VaistoVartojimas>();
        }

        public int PacientasId { get; set; }
        public int DraudimoNr { get; set; }
        public DateTime GimimoData { get; set; }
        public TimeSpan GimimoLaikas { get; set; }
        public string GimimoMiestas { get; set; }
        public string GimLigoninėsPav { get; set; }

        public virtual Vartotojas PacientasNavigation { get; set; }
        public virtual ICollection<AlergijaPacientas> AlergijaPacientas { get; set; }
        public virtual ICollection<LigonioVisitas> LigonioVisitas { get; set; }
        public virtual ICollection<Receptas> Receptas { get; set; }
        public virtual ICollection<Registracija> Registracija { get; set; }
        public virtual ICollection<VaistoVartojimas> VaistoVartojimas { get; set; }
    }
}
