using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoSolicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEstado = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSolicitud", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IntervaloHorario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IntervalosHorarios = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumerosVehiculos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntervaloHorario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdIntervaloHorario = table.Column<int>(type: "int", nullable: false),
                    Citas = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_IntervaloHorario_IdIntervaloHorario",
                        column: x => x.IdIntervaloHorario,
                        principalTable: "IntervaloHorario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreAccion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntregaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCita = table.Column<int>(type: "int", nullable: false),
                    IdIntervaloHorario = table.Column<int>(type: "int", nullable: false),
                    IdAccion = table.Column<int>(type: "int", nullable: false),
                    IdEstadoSolicitud = table.Column<int>(type: "int", nullable: false),
                    HoraCita = table.Column<TimeOnly>(type: "time", nullable: false),
                    NumeroEntrega = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cliente = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Origen = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destino = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CargaPrevista = table.Column<DateOnly>(type: "date", nullable: false),
                    EntregaPrevista = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrega", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrega_Accion_IdAccion",
                        column: x => x.IdAccion,
                        principalTable: "Accion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrega_Cita_IdCita",
                        column: x => x.IdCita,
                        principalTable: "Cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrega_EstadoSolicitud_IdEstadoSolicitud",
                        column: x => x.IdEstadoSolicitud,
                        principalTable: "EstadoSolicitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrega_IntervaloHorario_IdIntervaloHorario",
                        column: x => x.IdIntervaloHorario,
                        principalTable: "IntervaloHorario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Accion_EntregaId",
                table: "Accion",
                column: "EntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdIntervaloHorario",
                table: "Cita",
                column: "IdIntervaloHorario");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_IdAccion",
                table: "Entrega",
                column: "IdAccion");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_IdCita",
                table: "Entrega",
                column: "IdCita");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_IdEstadoSolicitud",
                table: "Entrega",
                column: "IdEstadoSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_IdIntervaloHorario",
                table: "Entrega",
                column: "IdIntervaloHorario");

            migrationBuilder.AddForeignKey(
                name: "FK_Accion_Entrega_EntregaId",
                table: "Accion",
                column: "EntregaId",
                principalTable: "Entrega",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accion_Entrega_EntregaId",
                table: "Accion");

            migrationBuilder.DropTable(
                name: "Entrega");

            migrationBuilder.DropTable(
                name: "Accion");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "EstadoSolicitud");

            migrationBuilder.DropTable(
                name: "IntervaloHorario");
        }
    }
}
