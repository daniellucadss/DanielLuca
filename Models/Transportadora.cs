using System.ComponentModel.DataAnnotations;

namespace DanielLuca.Models
{
    public class Transportadora
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome da Transportadora é obrigatório.")]
        [MaxLength(50)]
        [Display(Name = "Nome da Transportadora")]
        public string? Nome { get; set; }
    }
}