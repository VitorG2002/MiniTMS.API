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
                name: "funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    rg = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    telefone = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    clientes_id = table.Column<int>(type: "int", nullable: true),
                    destinatarios_id = table.Column<int>(type: "int", nullable: true),
                    funcionarios_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enderecos", x => x.id);
                    table.ForeignKey(
                        name: "fk_enderecos_clientes_clientes_id",
                        column: x => x.clientes_id,
                        principalTable: "clientes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_enderecos_destinatarios_destinatarios_id",
                        column: x => x.destinatarios_id,
                        principalTable: "destinatarios",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_enderecos_funcionarios_funcionarios_id",
                        column: x => x.funcionarios_id,
                        principalTable: "funcionarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "motoristas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    carro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    placa = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motoristas", x => x.id);
                    table.ForeignKey(
                        name: "fk_motoristas_funcionarios_id",
                        column: x => x.id,
                        principalTable: "funcionarios",
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
                    peso = table.Column<double>(type: "float", nullable: false),
                    comprimento = table.Column<double>(type: "float", nullable: false),
                    altura = table.Column<double>(type: "float", nullable: false),
                    profundidade = table.Column<double>(type: "float", nullable: false),
                    frete = table.Column<double>(type: "float", nullable: false),
                    prazo_de_entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clientes_id = table.Column<int>(type: "int", nullable: false),
                    destinatarios_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    nro_externo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motoristas_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pedidos", x => x.id);
                    table.ForeignKey(
                        name: "fk_pedidos_clientes_clientes_id",
                        column: x => x.clientes_id,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pedidos_destinatarios_destinatarios_id",
                        column: x => x.destinatarios_id,
                        principalTable: "destinatarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pedidos_motoristas_motoristas_id",
                        column: x => x.motoristas_id,
                        principalTable: "motoristas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_enderecos_clientes_id",
                table: "enderecos",
                column: "clientes_id");

            migrationBuilder.CreateIndex(
                name: "ix_enderecos_destinatarios_id",
                table: "enderecos",
                column: "destinatarios_id");

            migrationBuilder.CreateIndex(
                name: "ix_enderecos_funcionarios_id",
                table: "enderecos",
                column: "funcionarios_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_clientes_id",
                table: "pedidos",
                column: "clientes_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_destinatarios_id",
                table: "pedidos",
                column: "destinatarios_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_motoristas_id",
                table: "pedidos",
                column: "motoristas_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "destinatarios");

            migrationBuilder.DropTable(
                name: "motoristas");

            migrationBuilder.DropTable(
                name: "funcionarios");
        }
    }
}
