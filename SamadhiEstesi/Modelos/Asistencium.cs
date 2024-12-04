using System;
using System.Collections.Generic;

namespace SamadhiEstesi.Modelos
{
    public partial class Asistencium
    {
        public int IdAsistencia { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaAsistencia { get; set; }
        public string? Observacion { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; } = null!;
    }
}
