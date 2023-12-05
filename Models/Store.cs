namespace parcial2.Models;
using System.ComponentModel.DataAnnotations;

public class Store
{
    public int Id { get; set; }

    [Display(Name = "Distribuidor")]
    public string Name { get; set; }
    
    [Display(Name = "Fabricante")]
    public string Company { get; set; }

    public virtual ICollection<Footwear> Footwears { get; set; }

    public int? CompanyDataId { get; set; }

    public virtual CompanyData CompanyD { get; set; }
}    
