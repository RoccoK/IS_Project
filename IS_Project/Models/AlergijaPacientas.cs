using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class AlergijaPacientas
    {
        public int FkAlergijaId { get; set; }
        public int FkPacientasId { get; set; }
        public DateTime UzfiksuotaData { get; set; }
        public int Busena { get; set; }

        public virtual Alergija FkAlergija { get; set; }
        public virtual Pacientas FkPacientas { get; set; }
    }
}
