using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IS_Project.Models
{
    enum RegistracijosBusenos
    {
        Patvirtinta = 1,
        LaukiamaPatvirtinimo,
        Neatvykta,
        Atsaukta,
        Ivykdyta
    }

    enum Specializacijos
    {
        Akiu = 1,
        GalvosTraumu,
        Chirurgas,
        Budintis,
        Psichologas
    }

    enum DarboBusenos
    {
        Dirbantis = 1,
        Nebedirbantis
    }

    enum AlerigijosBusenos
    {
        Aktyvi = 1,
        Neaktyvi
    }
}