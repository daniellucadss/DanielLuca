using System.ComponentModel.DataAnnotations;

namespace DanielLuca.Models
{
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome do Vendedor é obrigatório.")]
        [MaxLength(50)]
        [Display(Name = "Nome do Vendedor")]
        public string? Nome { get; set; }
    }
}