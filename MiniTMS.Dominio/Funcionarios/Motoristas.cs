using MiniTMS.Dominio.Pedido;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniTMS.Dominio.Funcionarios
{
    [Table("motoristas")]
    public class Motoristas : Funcionarios
    {

        [Required(ErrorMessage = "Carro é um campo obrigatório!")]
        public string Carro { get; set; }

        [MaxLength(7, ErrorMessage = "A placa do carro tem no máximo 7 dígitos!")]
        [Required(ErrorMessage = "Placa é um campo obrigatório!")]
        public string Placa { get; set; }

        public List<Pedidos>? Pedidos { get; set; }

    }
}
