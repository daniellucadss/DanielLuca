using System.ComponentModel.DataAnnotations;

namespace DanielLuca.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome do Cliente é obrigatório.")]
        [MaxLength(50)]
        [Display(Name = "Nome do Cliente")]
        public string? Nome { get; set; }
    }
}