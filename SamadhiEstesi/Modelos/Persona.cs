using System;
using System.Collections.Generic;

namespace SamadhiEstesi.Modelos
{
    public partial class Persona
    {
        public Persona()
        {
            AntecedentesMedicos = new HashSet<AntecedentesMedico>();
            Asistencia = new HashSet<Asistencium>();
            RegistrosHistoricos = new HashSet<RegistrosHistorico>();
            Rutinas = new HashSet<Rutina>();
            Tokens = new HashSet<Token>();
        }

        public int IdPersona { get; set; }
        public string Rut { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int IdRol { get; set; }
        public string PasswordHash { get; set; } = null!;

        public virtual Role? IdRolNavigation { get; set; } = null!;
        public virtual ICollection<AntecedentesMedico> AntecedentesMedicos { get; set; }
        public virtual ICollection<Asistencium> Asistencia { get; set; }
        public virtual ICollection<RegistrosHistorico> RegistrosHistoricos { get; set; }
        public virtual ICollection<Rutina> Rutinas { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
