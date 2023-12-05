using System.ComponentModel.DataAnnotations;

namespace parcial2.ViewModels;

public class MovementCreateVM
{
    public int InvoiceNumber { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public int FootwearId { get; set; }
}