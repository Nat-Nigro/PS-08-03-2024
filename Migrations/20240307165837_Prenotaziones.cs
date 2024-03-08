using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbergoNigro.Migrations
{
    /// <inheritdoc />
    public partial class Prenotaziones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Camere_IdCameraID",
                table: "Prenotazione");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Clienti_Id1",
                table: "Prenotazione");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Pensione_IDPensioneID",
                table: "Prenotazione");

            migrationBuilder.RenameColumn(
                name: "IdCameraID",
                table: "Prenotazione",
                newName: "IDPensione");

            migrationBuilder.RenameColumn(
                name: "Id1",
                table: "Prenotazione",
                newName: "IDCliente");

            migrationBuilder.RenameColumn(
                name: "IDPensioneID",
                table: "Prenotazione",
                newName: "IDCamera");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IDPensioneID",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IDCamera");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IdCameraID",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IDPensione");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_Id1",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IDCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Camere_IDCamera",
                table: "Prenotazione",
                column: "IDCamera",
                principalTable: "Camere",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Clienti_IDCliente",
                table: "Prenotazione",
                column: "IDCliente",
                principalTable: "Clienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Pensione_IDPensione",
                table: "Prenotazione",
                column: "IDPensione",
                principalTable: "Pensione",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Camere_IDCamera",
                table: "Prenotazione");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Clienti_IDCliente",
                table: "Prenotazione");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Pensione_IDPensione",
                table: "Prenotazione");

            migrationBuilder.RenameColumn(
                name: "IDPensione",
                table: "Prenotazione",
                newName: "IdCameraID");

            migrationBuilder.RenameColumn(
                name: "IDCliente",
                table: "Prenotazione",
                newName: "Id1");

            migrationBuilder.RenameColumn(
                name: "IDCamera",
                table: "Prenotazione",
                newName: "IDPensioneID");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IDPensione",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IdCameraID");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IDCliente",
                table: "Prenotazione",
                newName: "IX_Prenotazione_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IDCamera",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IDPensioneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Camere_IdCameraID",
                table: "Prenotazione",
                column: "IdCameraID",
                principalTable: "Camere",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Clienti_Id1",
                table: "Prenotazione",
                column: "Id1",
                principalTable: "Clienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Pensione_IDPensioneID",
                table: "Prenotazione",
                column: "IDPensioneID",
                principalTable: "Pensione",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
