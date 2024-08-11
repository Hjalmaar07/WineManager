namespace WineManager.Models.WineMaker;

public class WineMaker : BaseModel
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public IEnumerable<WineBottle.WineBottle>? WineBottles { get; set; }
}
