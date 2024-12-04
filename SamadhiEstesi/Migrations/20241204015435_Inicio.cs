using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamadhiEstesi.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__roles__6ABCB5E0439298AF", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "suscripciones",
                columns: table => new
                {
                    id_suscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    periodicidad = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__suscripc__4E8926BBA03D3B62", x => x.id_suscripcion);
                });

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    id_persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rut = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    correo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    password_hash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__persona__228148B0216803C0", x => x.id_persona);
                    table.ForeignKey(
                        name: "FK__persona__id_rol__3B75D760",
                        column: x => x.id_rol,
                        principalTable: "roles",
                        principalColumn: "id_rol");
                });

            migrationBuilder.CreateTable(
                name: "antecedentes_medicos",
                columns: table => new
                {
                    id_antecedente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__antecede__3E014641ED9C5608", x => x.id_antecedente);
                    table.ForeignKey(
                        name: "FK__anteceden__id_pe__4BAC3F29",
                        column: x => x.id_persona,
                        principalTable: "persona",
                        principalColumn: "id_persona");
                });

            migrationBuilder.CreateTable(
                name: "asistencia",
                columns: table => new
                {
                    id_asistencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    fecha_asistencia = table.Column<DateTime>(type: "datetime", nullable: false),
                    observacion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__asistenc__D0454A9AD6C35D52", x => x.id_asistencia);
                    table.ForeignKey(
                        name: "FK__asistenci__id_pe__412EB0B6",
                        column: x => x.id_persona,
                        principalTable: "persona",
                        principalColumn: "id_persona");
                });

            migrationBuilder.CreateTable(
                name: "registros_historicos",
                columns: table => new
                {
                    id_registro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    accion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__registro__48155C1F8A77FA5E", x => x.id_registro);
                    table.ForeignKey(
                        name: "FK__registros__id_pe__4E88ABD4",
                        column: x => x.id_persona,
                        principalTable: "persona",
                        principalColumn: "id_persona");
                });

            migrationBuilder.CreateTable(
                name: "rutinas",
                columns: table => new
                {
                    id_rutina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    descripción = table.Column<string>(type: "text", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    comentario = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__rutinas__A284966765C0F60A", x => x.id_rutina);
                    table.ForeignKey(
                        name: "FK__rutinas__id_pers__48CFD27E",
                        column: x => x.id_persona,
                        principalTable: "persona",
                        principalColumn: "id_persona");
                });

            migrationBuilder.CreateTable(
                name: "tokens",
                columns: table => new
                {
                    id_token = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_expiracion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tokens__3C2FA9C4B13EA927", x => x.id_token);
                    table.ForeignKey(
                        name: "FK__tokens__id_perso__3E52440B",
                        column: x => x.id_persona,
                        principalTable: "persona",
                        principalColumn: "id_persona");
                });

            migrationBuilder.CreateIndex(
                name: "IX_antecedentes_medicos_id_persona",
                table: "antecedentes_medicos",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_asistencia_id_persona",
                table: "asistencia",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_persona_id_rol",
                table: "persona",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_registros_historicos_id_persona",
                table: "registros_historicos",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_rutinas_id_persona",
                table: "rutinas",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_tokens_id_persona",
                table: "tokens",
                column: "id_persona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "antecedentes_medicos");

            migrationBuilder.DropTable(
                name: "asistencia");

            migrationBuilder.DropTable(
                name: "registros_historicos");

            migrationBuilder.DropTable(
                name: "rutinas");

            migrationBuilder.DropTable(
                name: "suscripciones");

            migrationBuilder.DropTable(
                name: "tokens");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
