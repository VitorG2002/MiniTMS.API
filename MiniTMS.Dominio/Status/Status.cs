using MiniTMS.Dominio._Base;
using System.ComponentModel.DataAnnotations;

namespace MiniTMS.Dominio.Status
{
    public class Status : Entity
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        public string Nome { get; set; }
    }
}
