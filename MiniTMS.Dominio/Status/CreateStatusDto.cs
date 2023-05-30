using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Status
{
    public class CreateStatusDto
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        public string Nome { get; set; }
    }
}
