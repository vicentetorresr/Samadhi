using System;
using System.Collections.Generic;

namespace SamadhiEstesi.Modelos
{
    public partial class Role
    {
        public Role()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; } = null!;

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
