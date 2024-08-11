using WineManager.Dto.WineBottle;

namespace WineManager.Services.WineBottle;

public interface IWineBottleService
{
    Task<WineBottleResponseDto> CreateWineBottleAsync(WineBottleCreateDto wineBottleCreateDto);
    Task<WineBottleResponseDto?> GetWineBottleByIdAsync(Guid id);
    Task<WineBottleResponseDto> UpdateWineBottleAsync(WineBottleUpdateDto wineBottleUpdateDto);
    Task DeleteWineBottleAsync(Guid id);
    Task<IEnumerable<WineBottleResponseDto>?> FindWineBottlesAsync(WineBottleFilterDto wineBottleFilterDto);
}
