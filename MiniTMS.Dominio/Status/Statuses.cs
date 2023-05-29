using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Pedido;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Status
{
    public class Statuses : Entity
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        public string Nome { get; set; }

        public List<Pedidos>? Pedidos { get; set; }
    }
}
