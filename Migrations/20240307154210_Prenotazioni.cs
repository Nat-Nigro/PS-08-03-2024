using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbergoNigro.Migrations
{
    /// <inheritdoc />
    public partial class Prenotazioni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Prezzo",
                table: "Pensione",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Prenotazione",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrenotazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInizioSoggiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFineSoggiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Anno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acconto = table.Column<double>(type: "float", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    Id1 = table.Column<int>(type: "int", nullable: false),
                    IdCameraID = table.Column<int>(type: "int", nullable: false),
                    IDPensioneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazione", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prenotazione_Camere_IdCameraID",
                        column: x => x.IdCameraID,
                        principalTable: "Camere",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazione_Clienti_Id1",
                        column: x => x.Id1,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazione_Pensione_IDPensioneID",
                        column: x => x.IDPensioneID,
                        principalTable: "Pensione",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_Id1",
                table: "Prenotazione",
                column: "Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_IdCameraID",
                table: "Prenotazione",
                column: "IdCameraID");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_IDPensioneID",
                table: "Prenotazione",
                column: "IDPensioneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenotazione");

            migrationBuilder.AlterColumn<decimal>(
                name: "Prezzo",
                table: "Pensione",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
