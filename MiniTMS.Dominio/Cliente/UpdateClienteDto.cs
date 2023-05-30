using MiniTMS.Dominio.Endereco;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Cliente
{
    public class UpdateClienteDto
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(14)]
        [Required(ErrorMessage = "Cnpj/Cpf é um campo obrigatório!")]
        public string CnpjCpf { get; set; }

        [Required(ErrorMessage = "Nome/Nome fantasia é um campo obrigatório!")]
        public string NomeFantasia { get; set; }

        public string? RazaoSocial { get; set; }


        [Required(ErrorMessage = "Os campos do endereço são obrigatórios!")]
        public CreateEnderecoDto Endereco { get; set; }
    }
}
