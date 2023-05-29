using MiniTMS.Dominio._Base;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Pedido
{
    public class Pedidos : Entity
    {
        [Required(ErrorMessage = "Valor é um campo obrigatório!")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Peso é um campo obrigatório!")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "Comprimento é um campo obrigatório!")]
        public double Comprimento { get; set; }

        [Required(ErrorMessage = "Altura é um campo obrigatório!")]
        public double Altura { get; set; }

        [Required(ErrorMessage = "Profundidade é um campo obrigatório!")]
        public double Profundidade { get; set; }

        public double Frete { get; set; }

        [Required(ErrorMessage = "Prazo de Entrega é um campo obrigatório!")]
        public DateTime PrazoDeEntrega { get; set; }

        [Required(ErrorMessage = "ClientesId é um campo obrigatório!")]
        public int ClientesId { get; set; }

        [Required(ErrorMessage = "DestinatariosId é um campo obrigatório!")]
        public int DestinatariosId { get; set; }

        [Required(ErrorMessage = "StatusId é um campo obrigatório!")]
        public int StatusId { get; set; }

        public string? NroExterno { get; set; }

        [Required(ErrorMessage = "MotoristasId é um campo obrigatório!")]
        public int MotoristasId { get; set; }


    }
}
