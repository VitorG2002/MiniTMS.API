﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniTMS.Dados.Contextos;

#nullable disable

namespace MiniTMS.Dados.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230529033214_CriacaoDoBd")]
    partial class CriacaoDoBd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniTMS.Dominio.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CnpjCpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("cnpj_cpf");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome_fantasia");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("razao_social");

                    b.HasKey("Id")
                        .HasName("pk_clientes");

                    b.ToTable("clientes", (string)null);
                });

            modelBuilder.Entity("MiniTMS.Dominio.Destinatarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CnpjCpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("cnpj_cpf");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome_fantasia");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("razao_social");

                    b.HasKey("Id")
                        .HasName("pk_destinatarios");

                    b.ToTable("destinatarios", (string)null);
                });

            modelBuilder.Entity("MiniTMS.Dominio.Enderecos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cidade");

                    b.Property<int?>("ClientesId")
                        .HasColumnType("int")
                        .HasColumnName("clientes_id");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("complemento");

                    b.Property<int?>("DestinatariosId")
                        .HasColumnType("int")
                        .HasColumnName("destinatarios_id");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("endereco");

                    b.Property<int?>("FuncionariosId")
                        .HasColumnType("int")
                        .HasColumnName("funcionarios_id");

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasColumnName("numero");

                    b.Property<int>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("int")
                        .HasColumnName("telefone");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("uf");

                    b.HasKey("Id")
                        .HasName("pk_enderecos");

                    b.HasIndex("ClientesId")
                        .HasDatabaseName("ix_enderecos_clientes_id");

                    b.HasIndex("DestinatariosId")
                        .HasDatabaseName("ix_enderecos_destinatarios_id");

                    b.HasIndex("FuncionariosId")
                        .HasDatabaseName("ix_enderecos_funcionarios_id");

                    b.ToTable("enderecos", (string)null);
                });

            modelBuilder.Entity("MiniTMS.Dominio.Funcionarios.Funcionarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)")
                        .HasColumnName("rg");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sobrenome");

                    b.HasKey("Id");

                    b.ToTable("funcionarios", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MiniTMS.Dominio.Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Altura")
                        .HasColumnType("float")
                        .HasColumnName("altura");

                    b.Property<int>("ClientesId")
                        .HasColumnType("int")
                        .HasColumnName("clientes_id");

                    b.Property<double>("Comprimento")
                        .HasColumnType("float")
                        .HasColumnName("comprimento");

                    b.Property<int>("DestinatariosId")
                        .HasColumnType("int")
                        .HasColumnName("destinatarios_id");

                    b.Property<double>("Frete")
                        .HasColumnType("float")
                        .HasColumnName("frete");

                    b.Property<int>("MotoristasId")
                        .HasColumnType("int")
                        .HasColumnName("motoristas_id");

                    b.Property<string>("NroExterno")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nro_externo");

                    b.Property<double>("Peso")
                        .HasColumnType("float")
                        .HasColumnName("peso");

                    b.Property<DateTime>("PrazoDeEntrega")
                        .HasColumnType("datetime2")
                        .HasColumnName("prazo_de_entrega");

                    b.Property<double>("Profundidade")
                        .HasColumnType("float")
                        .HasColumnName("profundidade");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.Property<double>("Valor")
                        .HasColumnType("float")
                        .HasColumnName("valor");

                    b.HasKey("Id")
                        .HasName("pk_pedidos");

                    b.HasIndex("ClientesId")
                        .HasDatabaseName("ix_pedidos_clientes_id");

                    b.HasIndex("DestinatariosId")
                        .HasDatabaseName("ix_pedidos_destinatarios_id");

                    b.HasIndex("MotoristasId")
                        .HasDatabaseName("ix_pedidos_motoristas_id");

                    b.ToTable("pedidos", (string)null);
                });

            modelBuilder.Entity("MiniTMS.Dominio.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("pk_status");

                    b.ToTable("status", (string)null);
                });

            modelBuilder.Entity("MiniTMS.Dominio.Funcionarios.Motoristas", b =>
                {
                    b.HasBaseType("MiniTMS.Dominio.Funcionarios.Funcionarios");

                    b.Property<string>("Carro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("carro");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)")
                        .HasColumnName("placa");

                    b.ToTable("motoristas");
                });

            modelBuilder.Entity("MiniTMS.Dominio.Enderecos", b =>
                {
                    b.HasOne("MiniTMS.Dominio.Clientes", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("ClientesId")
                        .HasConstraintName("fk_enderecos_clientes_clientes_id");

                    b.HasOne("MiniTMS.Dominio.Destinatarios", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("DestinatariosId")
                        .HasConstraintName("fk_enderecos_destinatarios_destinatarios_id");

                    b.HasOne("MiniTMS.Dominio.Funcionarios.Funcionarios", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("FuncionariosId")
                        .HasConstraintName("fk_enderecos_funcionarios_funcionarios_id");
                });

            modelBuilder.Entity("MiniTMS.Dominio.Pedidos", b =>
                {
                    b.HasOne("MiniTMS.Dominio.Clientes", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("ClientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pedidos_clientes_clientes_id");

                    b.HasOne("MiniTMS.Dominio.Destinatarios", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("DestinatariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pedidos_destinatarios_destinatarios_id");

                    b.HasOne("MiniTMS.Dominio.Funcionarios.Motoristas", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("MotoristasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pedidos_motoristas_motoristas_id");
                });

            modelBuilder.Entity("MiniTMS.Dominio.Funcionarios.Motoristas", b =>
                {
                    b.HasOne("MiniTMS.Dominio.Funcionarios.Funcionarios", null)
                        .WithOne()
                        .HasForeignKey("MiniTMS.Dominio.Funcionarios.Motoristas", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_motoristas_funcionarios_id");
                });

            modelBuilder.Entity("MiniTMS.Dominio.Clientes", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("MiniTMS.Dominio.Destinatarios", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("MiniTMS.Dominio.Funcionarios.Funcionarios", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("MiniTMS.Dominio.Funcionarios.Motoristas", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
