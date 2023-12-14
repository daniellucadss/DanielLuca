using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanielLuca.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome do Produto é obrigatório.")]
        [MaxLength(30, ErrorMessage = "O campo Nome do Produto deve ter no máximo 30 caracteres.")]
        [Display(Name = "Nome do Produto")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição do Produto é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo Descrição do Produto deve ter no máximo 100 caracteres.")]
        [Display(Name = "Descrição do Produto")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo Quantidade em Estoque é obrigatório.")]
        [Display(Name = "Quantidade em Estoque")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Preço do Produto é obrigatório.")]
        [Display(Name = "Preço do Produto")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo Marca do Produto é obrigatório.")]
        [Display(Name = "Marca do Produto")]
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca? Marca { get; set; }
    }   
}