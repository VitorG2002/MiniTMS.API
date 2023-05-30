using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Produto
{
    public class UpdateProdutoDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Valor é um campo obrigatório!")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Peso é um campo obrigatório!")]
        public double Peso { get; set; }
    }
}
