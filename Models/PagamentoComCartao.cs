using System.ComponentModel.DataAnnotations;

namespace DanielLuca.Models
{
    public class PagamentoComCartao : TipoDePagamento
    {
        [Required(ErrorMessage = "O campo Número do Cartão é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O campo Número do Cartão deve ter no máximo 20 caracteres.")]
        [Display(Name = "Número do Cartão")]
        public string? NumeroDoCartao { get; set; }

        [Required(ErrorMessage = "O campo Bandeira do Cartão é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O campo Bandeira do Cartão deve ter no máximo 20 caracteres.")]
        [Display(Name = "Bandeira do Cartão")]
        public string? Bandeira { get; set; }

    }
}