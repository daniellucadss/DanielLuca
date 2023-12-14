using System.ComponentModel.DataAnnotations;

namespace DanielLuca.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome da Marca é obrigatório.")]
        [MaxLength(30)]
        [Display(Name = "Nome da Marca")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição da Marca é obrigatório.")]
        [MaxLength(100)]
        [Display(Name = "Descrição da Marca")]
        public string? Descricao { get; set; }
    }
}