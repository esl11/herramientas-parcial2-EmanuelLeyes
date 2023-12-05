using System.ComponentModel.DataAnnotations;

namespace parcial2.ViewModels;

public class MovementCreateVM
{
     [Display(Name = "Nro de Factura")]
    public int InvoiceNumber { get; set; }
    
     [Display(Name = "Fecha")]
    public DateTime Date { get; set; }

     [Display(Name = "Cantidad")]
    public int Quantity { get; set; }
    public int FootwearId { get; set; }
}