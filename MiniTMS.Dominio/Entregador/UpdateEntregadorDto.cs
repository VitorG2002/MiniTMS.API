using MiniTMS.Dominio.Endereco;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Entregador
{
    public class UpdateEntregadorDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é um campo obrigatório!")]
        public string Sobrenome { get; set; }

        [MaxLength(11, ErrorMessage = "CPF só pode conter 11 dígitos!")]
        public string Cpf { get; set; }

        [MaxLength(7, ErrorMessage = "Rg só pode conter 7 dígitos!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Carro é um campo obrigatório!")]
        public string Carro { get; set; }

        [MaxLength(7, ErrorMessage = "A placa do carro tem no máximo 7 dígitos!")]
        [Required(ErrorMessage = "Placa é um campo obrigatório!")]
        public string Placa { get; set; }

        public UpdateEnderecoDto Endereco { get; set; }
    }
}
