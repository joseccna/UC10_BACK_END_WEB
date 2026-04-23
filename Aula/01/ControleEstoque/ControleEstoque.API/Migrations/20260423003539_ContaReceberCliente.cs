using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.API.Migrations
{
    /// <inheritdoc />
    public partial class ContaReceberCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "ContaRecebers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContaRecebers_ClienteId",
                table: "ContaRecebers",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaRecebers_Usuarios_ClienteId",
                table: "ContaRecebers",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaRecebers_Usuarios_ClienteId",
                table: "ContaRecebers");

            migrationBuilder.DropIndex(
                name: "IX_ContaRecebers_ClienteId",
                table: "ContaRecebers");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "ContaRecebers");
        }
    }
}
