using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class VaistoVartojimas
    {
        public int FkVaistasId { get; set; }
        public int FkPacientasId { get; set; }
        public DateTime VartotaNuo { get; set; }
        public DateTime? VartotaIki { get; set; }

        public virtual Pacientas FkPacientas { get; set; }
        public virtual Vaistas FkVaistas { get; set; }
    }
}
