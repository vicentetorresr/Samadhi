using System;
using System.Collections.Generic;

namespace SamadhiEstesi.Modelos
{
    public partial class Token
    {
        public int IdToken { get; set; }
        public int IdPersona { get; set; }
        public string Token1 { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaExpiracion { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; } = null!;
    }
}
