using WineManager.Dto.WineMaker;

namespace WineManager.Services.WineMaker;

public interface IWineMakerService
{
    Task<WineMakerResponseDto> CreateWineMakerAsync(WineMakerCreateDto winemakerDto);
    Task<WineMakerResponseDto?> GetWineMakerByIdAsync(Guid id);
    Task<WineMakerResponseDto> UpdateWineMakerAsync(WineMakerUpdateDto winemakerDto);
    Task DeleteWineBottleAsync(Guid id);
    Task<IEnumerable<WineMakerResponseDto>?> FindWineMakersAsync(WineMakerFilterDto wineMakerFilterDto);
}
