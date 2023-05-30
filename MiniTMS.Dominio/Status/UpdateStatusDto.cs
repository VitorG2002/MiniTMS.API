using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Status
{
    public class UpdateStatusDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        public string Nome { get; set; }
    }
}
