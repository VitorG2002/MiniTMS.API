using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Pedido
{
    public class CreatePedidoDto
    {
        [Required(ErrorMessage = "Valor é um campo obrigatório!")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Frete é um campo obrigatório!")]
        public double Frete { get; set; }

        [Required(ErrorMessage = "Data Prevista é um campo obrigatório!")]
        public DateTime DataDeEntregaPrevista { get; set; }

        [Required(ErrorMessage = "Data de entrega é um campo obrigatório!")]
        public DateTime DataDeEntrega { get; set; }

        [Required(ErrorMessage = "ClientesId é um campo obrigatório!")]
        public int ClientesId { get; set; }


        [Required(ErrorMessage = "DestinatariosId é um campo obrigatório!")]
        public int DestinatariosId { get; set; }


        [Required(ErrorMessage = "StatusId é um campo obrigatório!")]
        public int StatusId { get; set; }

        public List<int> ProdutosIds { get; set; }

        public string? NroExterno { get; set; }

        [Required(ErrorMessage = "EntregadoresId é um campo obrigatório!")]
        public int EntregadoresId { get; set; }
    }
}
