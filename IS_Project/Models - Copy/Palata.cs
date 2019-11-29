using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IS_Project.Controllers
{
    public class Palata
    {
        [Key]
        int PalatosNr { get; set; }
        int VietuSkaicius { get; set; }
        int UzimtaVietu { get; set; }
    }
}
