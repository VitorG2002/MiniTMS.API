using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Produto
{
    public class ReadProdutoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Valor { get; set; }

        public double Peso { get; set; }
    }
}
