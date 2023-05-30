using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniTMS.Dados.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDoBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpj_cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    nome_fantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    razao_social = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "destinatarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpj_cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    nome_fantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    razao_social = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_destinatarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "entregadores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    rg = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    carro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    placa = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entregadores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false),
                    peso = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_produtos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    entregador_id = table.Column<int>(type: "int", nullable: true),
                    destinatario_id = table.Column<int>(type: "int", nullable: true),
                    cliente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enderecos", x => x.id);
                    table.ForeignKey(
                        name: "fk_enderecos_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enderecos_destinatarios_destinatario_id",
                        column: x => x.destinatario_id,
                        principalTable: "destinatarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enderecos_entregadores_entregador_id",
                        column: x => x.entregador_id,
                        principalTable: "entregadores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<double>(type: "float", nullable: false),
                    frete = table.Column<double>(type: "float", nullable: false),
                    data_de_entrega_prevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_de_entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clientes_id = table.Column<int>(type: "int", nullable: false),
                    destinatarios_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    nro_externo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    entregadores_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pedidos", x => x.id);
                    table.ForeignKey(
                        name: "fk_pedidos_clientes_clientes_id",
                        column: x => x.clientes_id,
                        principalTable: "clientes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_pedidos_destinatarios_destinatarios_id",
                        column: x => x.destinatarios_id,
                        principalTable: "destinatarios",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_pedidos_entregadores_entregadores_id",
                        column: x => x.entregadores_id,
                        principalTable: "entregadores",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_pedidos_status_status_id",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pedidos_produtos",
                columns: table => new
                {
                    pedidos_id = table.Column<int>(type: "int", nullable: false),
                    produtos_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pedidos_produtos", x => new { x.pedidos_id, x.produtos_id });
                    table.ForeignKey(
                        name: "fk_pedidos_produtos_pedidos_pedidos_id",
                        column: x => x.pedidos_id,
                        principalTable: "pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pedidos_produtos_produtos_produtos_id",
                        column: x => x.produtos_id,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_clientes_cnpj_cpf",
                table: "clientes",
                column: "cnpj_cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_destinatarios_cnpj_cpf",
                table: "destinatarios",
                column: "cnpj_cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_enderecos_cliente_id",
                table: "enderecos",
                column: "cliente_id",
                unique: true,
                filter: "[cliente_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_enderecos_destinatario_id",
                table: "enderecos",
                column: "destinatario_id",
                unique: true,
                filter: "[destinatario_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_enderecos_entregador_id",
                table: "enderecos",
                column: "entregador_id",
                unique: true,
                filter: "[entregador_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_entregadores_cpf",
                table: "entregadores",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_entregadores_rg",
                table: "entregadores",
                column: "rg",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_clientes_id",
                table: "pedidos",
                column: "clientes_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_destinatarios_id",
                table: "pedidos",
                column: "destinatarios_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_entregadores_id",
                table: "pedidos",
                column: "entregadores_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_status_id",
                table: "pedidos",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_produtos_produtos_id",
                table: "pedidos_produtos",
                column: "produtos_id");

            migrationBuilder.CreateIndex(
                name: "ix_status_nome",
                table: "status",
                column: "nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "pedidos_produtos");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "destinatarios");

            migrationBuilder.DropTable(
                name: "entregadores");

            migrationBuilder.DropTable(
                name: "status");
        }
    }
}
