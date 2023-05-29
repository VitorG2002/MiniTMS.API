using MiniTMS.Dominio._Base;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Endereco
{
    public class Enderecos : Entity
    {
        [MaxLength(11, ErrorMessage = "Telefone só pode conter 11 dígitos!")]
        [Required(ErrorMessage = "Telefone é um campo obrigatório!")]
        public int Telefone { get; set; }

        [MaxLength(8, ErrorMessage = "CEP só pode conter 8 dígitos!")]
        [Required(ErrorMessage = "Cep é um campo obrigatório!")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Endereço é um campo obrigatório!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Nº é um campo obrigatório!")]
        public int Numero { get; set; }

        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Bairro é um campo obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é um campo obrigatório!")]
        public string Cidade { get; set; }

        [MaxLength(2, ErrorMessage = "UF só pode conter 2 dígitos!")]
        [Required(ErrorMessage = "UF é um campo obrigatório!")]
        public string UF { get; set; }

    }
}
