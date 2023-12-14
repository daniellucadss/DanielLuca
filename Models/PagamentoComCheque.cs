using System.ComponentModel.DataAnnotations;

namespace DanielLuca.Models
{
    public class PagamentoComCheque : TipoDePagamento
    {      
        [Required(ErrorMessage = "O campo Número do Banco é obrigatório.")]
        [Display(Name = "Número do Banco")]
        public int NumeroDoBanco { get; set; }

        [Required(ErrorMessage = "O campo Nome do Banco é obrigatório.")]
        [MaxLength(10, ErrorMessage = "O Nome do Banco deve ter no máximo 10 caracteres.")]
        [Display(Name = "Nome do Banco")]
        public string? NomeDoBanco { get; set; }
    }
}