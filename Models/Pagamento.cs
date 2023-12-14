using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanielLuca.Models
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo data limite é obrigatória.")]
        [Display(Name = "Data Limite")]
        public DateTime DataLimite { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Display(Name = "Valor do Pagamento")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo 'O pagamento foi realizado?' é obrigatório.")]
        [Display(Name = "O pagamento foi realizado?")]
        [DisplayFormat(DataFormatString = "{0:Sim;Não}", NullDisplayText = "Não")]
        public bool Pago { get; set; }

        [Required(ErrorMessage = "O campo Nota De Venda é obrigatório.")]
        [Display(Name = "Nota de Venda")]
        [ForeignKey("NotaDeVendaId")]
        public int NotaDeVendaId { get; set; }
        public NotaDeVenda? NotaDeVenda { get; set; }
    }
}