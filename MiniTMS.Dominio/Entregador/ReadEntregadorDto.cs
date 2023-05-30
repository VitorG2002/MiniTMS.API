using MiniTMS.Dominio.Endereco;

namespace MiniTMS.Dominio.Entregador
{
    public class ReadEntregadorDto
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Carro { get; set; }

        public string Placa { get; set; }

        public ReadEnderecoDto Endereco { get; set; }
    }
}
