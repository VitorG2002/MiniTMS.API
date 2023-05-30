using MiniTMS.Dominio._Base;
using MiniTMS.Dominio.Cliente;
using MiniTMS.Dominio.Destinatario;
using MiniTMS.Dominio.Entregador;
using MiniTMS.Dominio.Produto;
using MiniTMS.Dominio.Status;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Pedido
{
    public class Pedidos : Entity
    {
        [Required(ErrorMessage = "Valor é um campo obrigatório!")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Frete é um campo obrigatório!")]
        public double Frete { get; set; }

        [Required(ErrorMessage = "Prazo de Entrega é um campo obrigatório!")]
        public DateTime PrazoDeEntrega { get; set; }

        [Required(ErrorMessage = "ClientesId é um campo obrigatório!")]
        public int ClientesId { get; set; }

        public Clientes Cliente { get; set; }

        [Required(ErrorMessage = "DestinatariosId é um campo obrigatório!")]
        public int DestinatariosId { get; set; }
        public Destinatarios Destinatario { get; set; }

        [Required(ErrorMessage = "StatusId é um campo obrigatório!")]
        public int StatusId { get; set; }

        public Statuses Status { get; set; }

        public string? NroExterno { get; set; }

        [Required(ErrorMessage = "MotoristasId é um campo obrigatório!")]
        public int MotoristasId { get; set; }

        public Entregadores Motoristas { get; set; }

        public List<Produtos> Produtos { get; set; }

    }
}
