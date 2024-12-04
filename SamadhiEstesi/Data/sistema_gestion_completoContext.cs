using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SamadhiEstesi.Modelos;

namespace SamadhiEstesi.Data
{
    public partial class sistema_gestion_completoContext : DbContext
    {
        public sistema_gestion_completoContext()
        {
        }

        public sistema_gestion_completoContext(DbContextOptions<sistema_gestion_completoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AntecedentesMedico> AntecedentesMedicos { get; set; } = null!;
        public virtual DbSet<Asistencium> Asistencia { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<RegistrosHistorico> RegistrosHistoricos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Rutina> Rutinas { get; set; } = null!;
        public virtual DbSet<Suscripcione> Suscripciones { get; set; } = null!;
        public virtual DbSet<Token> Tokens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PABLO-NOTEBOOK\\SQLEXPRESS;Database=sistema_gestion_completo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AntecedentesMedico>(entity =>
            {
                entity.HasKey(e => e.IdAntecedente)
                    .HasName("PK__antecede__3E014641ED9C5608");

                entity.ToTable("antecedentes_medicos");

                entity.HasIndex(e => e.IdPersona, "IX_antecedentes_medicos_id_persona");

                entity.Property(e => e.IdAntecedente).HasColumnName("id_antecedente");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.AntecedentesMedicos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__anteceden__id_pe__4BAC3F29");
            });

            modelBuilder.Entity<Asistencium>(entity =>
            {
                entity.HasKey(e => e.IdAsistencia)
                    .HasName("PK__asistenc__D0454A9AD6C35D52");

                entity.ToTable("asistencia");

                entity.HasIndex(e => e.IdPersona, "IX_asistencia_id_persona");

                entity.Property(e => e.IdAsistencia).HasColumnName("id_asistencia");

                entity.Property(e => e.FechaAsistencia)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_asistencia");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Observacion)
                    .HasColumnType("text")
                    .HasColumnName("observacion");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__asistenci__id_pe__412EB0B6");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__persona__228148B0216803C0");

                entity.ToTable("persona");

                entity.HasIndex(e => e.IdRol, "IX_persona_id_rol");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password_hash");

                entity.Property(e => e.Rut)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("rut");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__persona__id_rol__3B75D760");
            });

            modelBuilder.Entity<RegistrosHistorico>(entity =>
            {
                entity.HasKey(e => e.IdRegistro)
                    .HasName("PK__registro__48155C1F8A77FA5E");

                entity.ToTable("registros_historicos");

                entity.HasIndex(e => e.IdPersona, "IX_registros_historicos_id_persona");

                entity.Property(e => e.IdRegistro).HasColumnName("id_registro");

                entity.Property(e => e.Accion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("accion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.RegistrosHistoricos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__registros__id_pe__4E88ABD4");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__roles__6ABCB5E0439298AF");

                entity.ToTable("roles");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.NombreRol).HasColumnName("Nombre_Rol");
            });

            modelBuilder.Entity<Rutina>(entity =>
            {
                entity.HasKey(e => e.IdRutina)
                    .HasName("PK__rutinas__A284966765C0F60A");

                entity.ToTable("rutinas");

                entity.HasIndex(e => e.IdPersona, "IX_rutinas_id_persona");

                entity.Property(e => e.IdRutina).HasColumnName("id_rutina");

                entity.Property(e => e.Comentario)
                    .HasColumnType("text")
                    .HasColumnName("comentario");

                entity.Property(e => e.Descripción)
                    .HasColumnType("text")
                    .HasColumnName("descripción");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Rutinas)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__rutinas__id_pers__48CFD27E");
            });

            modelBuilder.Entity<Suscripcione>(entity =>
            {
                entity.HasKey(e => e.IdSuscripcion)
                    .HasName("PK__suscripc__4E8926BBA03D3B62");

                entity.ToTable("suscripciones");

                entity.Property(e => e.IdSuscripcion).HasColumnName("id_suscripcion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Periodicidad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("periodicidad");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.HasKey(e => e.IdToken)
                    .HasName("PK__tokens__3C2FA9C4B13EA927");

                entity.ToTable("tokens");

                entity.HasIndex(e => e.IdPersona, "IX_tokens_id_persona");

                entity.Property(e => e.IdToken).HasColumnName("id_token");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaExpiracion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_expiracion");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Token1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Tokens)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tokens__id_perso__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
