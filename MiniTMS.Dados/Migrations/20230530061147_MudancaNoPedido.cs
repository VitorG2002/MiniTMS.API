using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniTMS.Dados.Migrations
{
    /// <inheritdoc />
    public partial class MudancaNoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nro_externo",
                table: "pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nro_externo",
                table: "pedidos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
