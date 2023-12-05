using System.ComponentModel.DataAnnotations;

namespace parcial2.ViewModels;

public class FootwearEditVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Release { get; set; }
    public string Gender { get; set; }
    public decimal Price { get; set; }
    public string Company { get; set; }
    public string Image { get; set; }
    
    [Display(Name = "Distribuidor")]
    public List<int> StoreIds { get; set; }

}