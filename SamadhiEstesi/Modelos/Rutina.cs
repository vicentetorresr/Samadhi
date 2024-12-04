using System;
using System.Collections.Generic;

namespace SamadhiEstesi.Modelos
{
    public partial class Rutina
    {
        public int IdRutina { get; set; }
        public int IdPersona { get; set; }
        public string Descripción { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string? Comentario { get; set; }
        public bool? Estado { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; } = null!;
    }
}
