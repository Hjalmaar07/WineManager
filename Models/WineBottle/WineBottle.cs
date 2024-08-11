namespace WineManager.Models.WineBottle;

public class WineBottle : BaseModel
{
    public Guid WinemakerId { get; set; }
    public string? Name { get; set; }
    public int? Year { get; set; }
    public string? Size { get; set; }
    public int? CountInCellar { get; set; }
    public StyleEnum? Style { get; set; }
    public TasteEnum? Taste { get; set; }
    public string? Description { get; set; }
    public string? FoodPairing { get; set; }
    public string? Link { get; set; }
    public string? Image { get; set; }
}
