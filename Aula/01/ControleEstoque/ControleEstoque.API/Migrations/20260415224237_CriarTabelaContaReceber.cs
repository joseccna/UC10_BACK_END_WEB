using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.API.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaContaReceber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntemPedidos_Pedidos_PedidoId",
                table: "IntemPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_IntemPedidos_Produtos_ProdutoId",
                table: "IntemPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IntemPedidos",
                table: "IntemPedidos");

            migrationBuilder.RenameTable(
                name: "IntemPedidos",
                newName: "ItemPedidos");

            migrationBuilder.RenameIndex(
                name: "IX_IntemPedidos_ProdutoId",
                table: "ItemPedidos",
                newName: "IX_ItemPedidos_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_IntemPedidos_PedidoId",
                table: "ItemPedidos",
                newName: "IX_ItemPedidos_PedidoId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "ItemPedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPedidos",
                table: "ItemPedidos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContaRecebers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaRecebers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedidos_Pedidos_PedidoId",
                table: "ItemPedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedidos_Produtos_ProdutoId",
                table: "ItemPedidos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedidos_Pedidos_PedidoId",
                table: "ItemPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedidos_Produtos_ProdutoId",
                table: "ItemPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "ContaRecebers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPedidos",
                table: "ItemPedidos");

            migrationBuilder.RenameTable(
                name: "ItemPedidos",
                newName: "IntemPedidos");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPedidos_ProdutoId",
                table: "IntemPedidos",
                newName: "IX_IntemPedidos_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPedidos_PedidoId",
                table: "IntemPedidos",
                newName: "IX_IntemPedidos_PedidoId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "IntemPedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IntemPedidos",
                table: "IntemPedidos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IntemPedidos_Pedidos_PedidoId",
                table: "IntemPedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IntemPedidos_Produtos_ProdutoId",
                table: "IntemPedidos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
