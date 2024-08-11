using WineManager.Dto.WineBottle;

namespace WineManager.Dto.WineMaker;

public class WineMakerResponseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public IEnumerable<WineBottleResponseDto>? WineBottles { get; set; }
}
