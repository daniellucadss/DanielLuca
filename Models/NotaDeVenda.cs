using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanielLuca.Models
{
    public class NotaDeVenda
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Data da Venda é obrigatória.")]
        [Display(Name = "Data da Venda")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo Nome do Cliente é obrigatório.")]
        [Display(Name = "Nome do Cliente")]
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        [Required(ErrorMessage = "O campo Nome do Vendedor é obrigatório.")]
        [Display(Name = "Nome do Vendedor")]
        public int VendedorId { get; set; }
        [ForeignKey("VendedorId")]
        public Vendedor? Vendedor { get; set; }

        [Required(ErrorMessage = "O campo Nome da Transportadora é obrigatório.")]
        [Display(Name = "Nome da Transportadora")]
        public int TransportadoraId { get; set; }
        [ForeignKey("TransportadoraId")]
        public Transportadora? Transportadora { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório.")]
        [Display(Name = "Status Da Nota De Venda")]
        public StatusNotaDeVenda Status { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Pagamento é obrigatório.")]
        [Display(Name = "Tipo de Pagamento")]
        public int TipoDePagamentoId { get; set; }
        [ForeignKey("TipoDePagamentoId")]
        public TipoDePagamento? TipoDePagamento { get; set; }
    }
}