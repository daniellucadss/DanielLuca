using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanielLuca.Models
{
    public class Item
    {   
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Preço do Item é obrigatório.")]
        [Display(Name = "Preço do Item")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo Percentual é obrigatório.")]
        [Display(Name = "Percentual do Item")]
        public int Percentual { get; set; }

        [Required(ErrorMessage = "O campo Quantidade do Item é obrigatório.")]
        [Display(Name = "Quantidade do Item")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Produto é obrigatório.")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public Produto? Produto { get; set; }

        [Required(ErrorMessage = "O campo Nota De Venda é obrigatório.")]
        [Display(Name = "Nota de Venda")]
        [ForeignKey("NotaDeVendaId")]
        public int NotaDeVendaId { get; set; }
        public NotaDeVenda? NotaDeVenda { get; set; }
    }
}