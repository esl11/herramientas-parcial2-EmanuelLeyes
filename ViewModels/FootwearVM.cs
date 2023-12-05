using System.ComponentModel.DataAnnotations;

namespace parcial2.ViewModels;

public class FootwearVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Release { get; set; }
    public string Gender { get; set; }
    public string Company { get; set; }
    public string Image { get; set; }
    [Display(Name = "Marca")]
    public string? StoreName { get; set; }
    public int Stock { get; set; }
}