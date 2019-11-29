using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Kabinetas
    {
        public Kabinetas()
        {
            DaktarasKabinetas = new HashSet<DaktarasKabinetas>();
        }

        public int KabinetasId { get; set; }
        public int KabNr { get; set; }

        public virtual ICollection<DaktarasKabinetas> DaktarasKabinetas { get; set; }
    }
}
