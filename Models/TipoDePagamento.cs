using System.ComponentModel.DataAnnotations;

namespace DanielLuca.Models
{
    public class TipoDePagamento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome do Cobrado é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo Nome do Cobrado deve ter no máximo 30 caracteres.")]
        [Display(Name = "Nome do Cobrado")]
        public string? NomeDoCobrado { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(100, ErrorMessage = "O campo Nome do Cobrado deve ter no máximo 100 caracteres.")]
        [Display(Name = "Informações Adicionais")]
        public string? InformacoesAdicionais { get; set; }
        
        [Display(Name = "Tipo De Pagamento")]
        public string? Tipo { get; set; }
    }
}