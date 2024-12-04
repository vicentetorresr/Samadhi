using System;
using System.Collections.Generic;

namespace SamadhiEstesi.Modelos
{
    public partial class Suscripcione
    {
        public int IdSuscripcion { get; set; }
        public string? Descripcion { get; set; }
        public string Periodicidad { get; set; } = null!;
        public decimal Valor { get; set; }
        public bool? Estado { get; set; }
    }
}
