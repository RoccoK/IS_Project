using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Zinute
    {
        public int ZinuteId { get; set; }
        public DateTime Data { get; set; }
        public string Tekstas { get; set; }
        public int FkAdministratoriusId { get; set; }
        public int FkVartotojasId { get; set; }

        public virtual Administratorius FkAdministratorius { get; set; }
        public virtual Vartotojas FkVartotojas { get; set; }
    }
}
