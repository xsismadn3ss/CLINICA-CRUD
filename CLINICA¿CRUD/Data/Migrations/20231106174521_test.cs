using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLINICA_CRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alergium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alergia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergium", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: true),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discapacidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tratamiento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discapacidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfermedad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enfermedad1 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedad", x => x.Id);
                });

            /*migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apelido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoResponsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    TelefonoResponsable = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });*/

            migrationBuilder.CreateTable(
                name: "Tratamiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tratamiento1 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroMedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: true),
                    IdDiscapacidad = table.Column<int>(type: "int", nullable: true),
                    IdAlergia = table.Column<int>(type: "int", nullable: true),
                    IdEnfermedad = table.Column<int>(type: "int", nullable: true),
                    IdTratamiento = table.Column<int>(type: "int", nullable: true),
                    IdAlergiaNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdDiscapacidadNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdEnfermedadNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdPacienteNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdTratamientoNavigationId = table.Column<int>(type: "int", nullable: true),
                    CitasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroMedico_Alergium_IdAlergiaNavigationId",
                        column: x => x.IdAlergiaNavigationId,
                        principalTable: "Alergium",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroMedico_Cita_CitasId",
                        column: x => x.CitasId,
                        principalTable: "Cita",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroMedico_Discapacidad_IdDiscapacidadNavigationId",
                        column: x => x.IdDiscapacidadNavigationId,
                        principalTable: "Discapacidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroMedico_Enfermedad_IdEnfermedadNavigationId",
                        column: x => x.IdEnfermedadNavigationId,
                        principalTable: "Enfermedad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroMedico_Paciente_IdPacienteNavigationId",
                        column: x => x.IdPacienteNavigationId,
                        principalTable: "Paciente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroMedico_Tratamiento_IdTratamientoNavigationId",
                        column: x => x.IdTratamientoNavigationId,
                        principalTable: "Tratamiento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMedico_CitasId",
                table: "RegistroMedico",
                column: "CitasId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMedico_IdAlergiaNavigationId",
                table: "RegistroMedico",
                column: "IdAlergiaNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMedico_IdDiscapacidadNavigationId",
                table: "RegistroMedico",
                column: "IdDiscapacidadNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMedico_IdEnfermedadNavigationId",
                table: "RegistroMedico",
                column: "IdEnfermedadNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMedico_IdPacienteNavigationId",
                table: "RegistroMedico",
                column: "IdPacienteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMedico_IdTratamientoNavigationId",
                table: "RegistroMedico",
                column: "IdTratamientoNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroMedico");

            migrationBuilder.DropTable(
                name: "Alergium");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Discapacidad");

            migrationBuilder.DropTable(
                name: "Enfermedad");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Tratamiento");
        }
    }
}
