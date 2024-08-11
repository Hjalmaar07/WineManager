using WineManager.Models.WineBottle;

namespace WineManager.Dto.WineBottle;

public class WineBottleFilterDto
{
    public string? Name { get; set; }
    public int? Year { get; set; }
    public string? Size { get; set; }
    public int? CountInCellar { get; set; }
    public StyleEnum? Style { get; set; }
    public TasteEnum? Taste { get; set; }
    public string? Description { get; set; }
    public string? FoodPairing { get; set; }
}
