using System.ComponentModel.DataAnnotations;

namespace parcial2.ViewModels;

public class FootwearCreateVM
{
    public int Id { get; set; }

    [Display(Name = "Modelo")]
    public string Name { get; set; }

    [Display(Name = "Año/temporada")]
    public int Release { get; set; }

    [Display(Name = "Genero")]
    public string Gender { get; set; }

    [Display(Name = "Precio")]
    public decimal Price { get; set; }
    
    [Display(Name = "Fabricante")]
    public string Company { get; set; }

    [Display(Name = "URl de imagen")]
    public string Image { get; set; }

    [Display(Name = "Fabricante")]
    public List<int> StoreIds { get; set; }
}