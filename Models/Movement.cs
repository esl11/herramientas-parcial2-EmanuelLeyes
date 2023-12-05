using parcial2.Utils;
using System.ComponentModel.DataAnnotations;
namespace parcial2.Models;

public class Movement
{
    public int Id { get; set; }

    [Display(Name = "Factura nro")]
    public int InvoiceNumber { get; set; }
    
    [Display(Name = "Fecha")]
    public DateTime Date { get; set; }
    public MovementType TypeM { get; set; }
    
    [Display(Name = "Cantidad")]
    
    public int Quantity { get; set; }
    public int FootwearId { get; set; }
    public virtual Footwear Footwear { get; set; }
}
