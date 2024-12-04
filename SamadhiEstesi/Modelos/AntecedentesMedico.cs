using System;
using System.Collections.Generic;

namespace SamadhiEstesi.Modelos
{
    public partial class AntecedentesMedico
    {
        public int IdAntecedente { get; set; }
        public int IdPersona { get; set; }
        public string Tipo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; } = null!;
    }
}
