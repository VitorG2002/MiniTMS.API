using MiniTMS.Dominio.Endereco;

namespace MiniTMS.Dominio.Destinatario
{
    public class ReadDestinatarioDto
    {
        public int Id { get; set; }
        public string CnpjCpf { get; set; }

        public string NomeFantasia { get; set; }

        public string? RazaoSocial { get; set; }

        public ReadEnderecoDto Endereco { get; set; }
    }
}
