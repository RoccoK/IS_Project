using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class DaktarasKabinetas
    {
        public int FkDaktarasId { get; set; }
        public int FkKabinetasId { get; set; }

        public virtual Daktaras FkDaktaras { get; set; }
        public virtual Kabinetas FkKabinetas { get; set; }
    }
}
