using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class Administratorius
    {
        public Administratorius()
        {
            Zinute = new HashSet<Zinute>();
        }

        public int AdministratoriusId { get; set; }
        public string PrisijungimoAlias { get; set; }
        public DateTime PradetaDirbti { get; set; }
        public DateTime? BaigtaDirbti { get; set; }
        public int Busena { get; set; }

        public virtual Vartotojas AdministratoriusNavigation { get; set; }
        public virtual ICollection<Zinute> Zinute { get; set; }
    }
}
