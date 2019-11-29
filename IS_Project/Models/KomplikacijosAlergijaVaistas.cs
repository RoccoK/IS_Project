using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class KomplikacijosAlergijaVaistas
    {
        public int FkVaistasId { get; set; }
        public int FkAlergijaId { get; set; }

        public virtual Alergija FkAlergija { get; set; }
        public virtual Vaistas FkVaistas { get; set; }
    }
}
