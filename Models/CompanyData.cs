namespace parcial2.Models;
using System.ComponentModel.DataAnnotations;

public class CompanyData
{
    public int Id { get; set; }

    [Display(Name = "Pagina web")]
    public string Web { get; set; }
    
    [Display(Name = "Teléfono")]
    public string PhoneNumber { get; set; }

    public virtual ICollection<Store> Stores { get; set; }
    
}