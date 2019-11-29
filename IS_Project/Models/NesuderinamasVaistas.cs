using System;
using System.Collections.Generic;

namespace IS_Project.Models
{
    public partial class NesuderinamasVaistas
    {
        public int FkVaistasId1 { get; set; }
        public int FkVaistasId2 { get; set; }

        public virtual Vaistas FkVaistasId1Navigation { get; set; }
        public virtual Vaistas FkVaistasId2Navigation { get; set; }
    }
}
