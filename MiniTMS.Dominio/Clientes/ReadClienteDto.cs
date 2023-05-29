using MiniTMS.Dominio.Endereco;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Cliente
{
    public class ReadClienteDto
    {
        public string CnpjCpf { get; set; }

        public string NomeFantasia { get; set; }

        public string? RazaoSocial { get; set; }

        public List<Enderecos> Enderecos { get; set; }
    }
}
