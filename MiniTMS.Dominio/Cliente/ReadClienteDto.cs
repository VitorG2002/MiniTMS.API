using MiniTMS.Dominio.Endereco;

namespace MiniTMS.Dominio.Cliente
{
    public class ReadClienteDto
    {
        public int Id { get; set; }
        public string CnpjCpf { get; set; }

        public string NomeFantasia { get; set; }

        public string? RazaoSocial { get; set; }

        public ReadEnderecoDto Endereco { get; set; }
    }
}
