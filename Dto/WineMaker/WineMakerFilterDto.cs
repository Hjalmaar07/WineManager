using WineManager.Dto.WineBottle;

namespace WineManager.Dto.WineMaker;

public class WineMakerFilterDto
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public WineBottleFilterDto? WineBottle { get; set; }
}
