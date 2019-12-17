﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Project.Models
{
    public partial class Registracija
    {
        [DisplayName("id")]
        public int RegistracijaId { get; set; }
        [DisplayName("Pateikimo data")]
        public DateTime PateikimoData { get; set; }
        [DisplayName("Būsena")]
        public int Busena { get; set; }
        [DisplayName("Kviesta greitoji")]
        public sbyte KviestaGreitoji { get; set; }
        public int FkPacientasId { get; set; }
        [DisplayName("Daktaras")]
        public int FkDaktarasId { get; set; }
        [DisplayName("Vizito data")]
        public DateTime VisitoData { get; set; }

        public virtual Daktaras FkDaktaras { get; set; }
        public virtual Pacientas FkPacientas { get; set; }
    }
}
