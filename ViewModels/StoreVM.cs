namespace parcial2.ViewModels;
using System.ComponentModel.DataAnnotations;
public class StoreVM
{
    public int Id { get; set; }

    [Display(Name = "Distribuidor")]
    public string Name { get; set; }

    [Display(Name = "Fabricante")]
    public string Company { get; set; }
}