﻿using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Endereco;
using MiniTMS.Dominio.Pedido;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Destinatarios
{
    public class Destinatarios : Entity
    {
        [MaxLength(14, ErrorMessage = "Cnpj/Cpf pode conter até 14 dígitos!")]
        [Required(ErrorMessage = "Cnpj/Cpf é um campo obrigatório!")]
        public string CnpjCpf { get; set; }

        [Required(ErrorMessage = "Nome/Nome fantasia é um campo obrigatório!")]
        public string NomeFantasia { get; set; }

        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "Os campos do endereço são obrigatórios!")]
        public List<Enderecos> Enderecos { get; set; }

        public List<Pedidos>? Pedidos { get; set; }
    }
}
