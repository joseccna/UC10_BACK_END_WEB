using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.API.Migrations
{
    /// <inheritdoc />
    public partial class TornarClienteObrigatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaRecebers_Usuarios_ClienteId",
                table: "ContaRecebers");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "ContaRecebers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContaRecebers_Usuarios_ClienteId",
                table: "ContaRecebers",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaRecebers_Usuarios_ClienteId",
                table: "ContaRecebers");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "ContaRecebers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaRecebers_Usuarios_ClienteId",
                table: "ContaRecebers",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
