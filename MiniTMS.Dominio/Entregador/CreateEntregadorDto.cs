using MiniTMS.Dominio.Endereco;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Entregador
{
    public class CreateEntregadorDto
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é um campo obrigatório!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "CPF é um campo obrigatório!")]
        [MaxLength(11, ErrorMessage = "CPF só pode conter 11 dígitos!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "RG é um campo obrigatório!")]
        [MaxLength(9, ErrorMessage = "Rg só pode conter 9 dígitos!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Carro é um campo obrigatório!")]
        public string Carro { get; set; }

        [MaxLength(7, ErrorMessage = "A placa do carro tem no máximo 7 dígitos!")]
        [Required(ErrorMessage = "Placa é um campo obrigatório!")]
        public string Placa { get; set; }

        public UpdateEnderecoDto Endereco { get; set; }
    }
}
