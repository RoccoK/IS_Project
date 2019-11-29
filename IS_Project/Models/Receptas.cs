using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Receptas
    {
        public int FkVaistasId { get; set; }
        public int FkPacientasId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan? Laikas { get; set; }
        public int ReceptoNr { get; set; }

        public virtual Pacientas FkPacientas { get; set; }
        public virtual Vaistas FkVaistas { get; set; }
    }
}
