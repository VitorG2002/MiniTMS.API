using MiniTMS.Dominio.Cliente;
using MiniTMS.Dominio.Destinatario;
using MiniTMS.Dominio.Entregador;
using MiniTMS.Dominio.Produto;
using MiniTMS.Dominio.Status;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Pedido
{
    public class ReadPedidoDto
    {
        public int Id { get; set; }
        public double Valor { get; set; }

        public double Frete { get; set; }

        public DateTime DataDeEntrega { get; set; }

        public DateTime DataDeEntregaPrevista { get; set; }

        public int ClientesId { get; set; }

        public int DestinatariosId { get; set; }

        public int StatusId { get; set; }

        public int EntregadoresId { get; set; }

        public ReadClienteDto Cliente { get; set; }

        public ReadStatusDto Status { get; set; }

        public ReadDestinatarioDto Destinatario { get; set; }

        public ReadEntregadorDto Entregador { get; set; }

        public List<ReadProdutoDto> Produtos { get; set; }
    }
}
