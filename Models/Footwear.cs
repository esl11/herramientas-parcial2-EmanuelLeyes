namespace parcial2.Models;
using System.ComponentModel.DataAnnotations;

public class Footwear
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

    [Display(Name = "URL de imagen")]
    public string Image { get; set; }
    public int Stock { get; set; }

    [Display(Name = "Distribuidor")]
    public virtual ICollection<Store> Stores { get; set; }
}
