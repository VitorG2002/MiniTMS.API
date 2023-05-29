using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Endereco;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniTMS.Dominio.Funcionarios
{
    [Table("funcionarios")]
    public class Funcionarios : Entity
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é um campo obrigatório!")]
        public string Sobrenome { get; set; }

        [MaxLength(11, ErrorMessage = "CPF só pode conter 11 dígitos!")]
        public string Cpf { get; set; }

        [MaxLength(7, ErrorMessage = "Rg só pode conter 7 dígitos!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Os campos do endereço são obrigatórios!")]
        public List<Enderecos> Enderecos { get; set; }

    }
}
