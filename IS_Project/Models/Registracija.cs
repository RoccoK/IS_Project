using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Registracija
    {
        public int RegistracijaId { get; set; }
        public DateTime PateikimoData { get; set; }
        public int Busena { get; set; }
        public sbyte KviestaGreitoji { get; set; }
        public int FkPacientasId { get; set; }
        public int FkDaktarasId { get; set; }
        public DateTime VisitoData { get; set; }

        public virtual Daktaras FkDaktaras { get; set; }
        public virtual Pacientas FkPacientas { get; set; }
    }
}
