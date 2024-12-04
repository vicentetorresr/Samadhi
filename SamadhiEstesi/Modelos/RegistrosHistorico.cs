using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamadhiEstesi.Modelos
{
    [Table("RegistrosHistoricos")]
    public partial class RegistrosHistorico
    {
        public int IdRegistro { get; set; }
        public int IdPersona { get; set; }
        public string Accion { get; set; } = null!;
        public DateTime Fecha { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; } = null!;
    }
}
