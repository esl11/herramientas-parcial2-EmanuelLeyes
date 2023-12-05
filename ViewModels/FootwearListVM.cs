namespace parcial2.ViewModels;

public class FootwearListVM
{   
    public List<FootwearVM> Footwears { get; set; } = new List<FootwearVM>();
    public string? Filter { get; set; }
}