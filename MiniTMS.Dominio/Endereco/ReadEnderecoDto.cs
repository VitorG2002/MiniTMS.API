namespace MiniTMS.Dominio.Endereco
{
    public class ReadEnderecoDto
    {
        public int Telefone { get; set; }

        public string Cep { get; set; }

        public string Endereco { get; set; }

        public int Numero { get; set; }

        public string? Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }
    }
}
