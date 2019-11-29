using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class LigonioVisitas
    {
        public int LigonioVisitasId { get; set; }
        public DateTime DataNuo { get; set; }
        public DateTime? DataIki { get; set; }
        public string Komentarai { get; set; }
        public int FkLigaId { get; set; }
        public int FkPalataId { get; set; }
        public int FkPacientasId { get; set; }

        public virtual Liga FkLiga { get; set; }
        public virtual Pacientas FkPacientas { get; set; }
        public virtual Palata FkPalata { get; set; }
    }
}
