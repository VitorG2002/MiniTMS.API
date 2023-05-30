using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Pedido;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Produto
{
    public class Produtos : Entity
    {

        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Valor é um campo obrigatório!")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Peso é um campo obrigatório!")]
        public double Peso { get; set; }

        public List<Pedidos>? Pedidos { get; set; }

    }
}
