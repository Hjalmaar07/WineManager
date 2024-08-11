using AutoMapper;
using WineManager.Dto.WineBottle;
using WineManager.Repositories.WineBottle;

namespace WineManager.Services.WineBottle;

public class WineBottleService : IWineBottleService
{
    private readonly IMapper _mapper;
    private readonly IWineBottleRepository _wineBottleRepository;

    public WineBottleService(IMapper mapper, IWineBottleRepository wineBottleRepository)
    {
        _mapper = mapper;
        _wineBottleRepository = wineBottleRepository;
    }

    public async Task<WineBottleResponseDto> CreateWineBottleAsync(WineBottleCreateDto wineBottleDto)
    {
        var wineBottle = _mapper.Map<Models.WineBottle.WineBottle>(wineBottleDto);
        CreateId(wineBottle);

        return _mapper.Map<WineBottleResponseDto>(await _wineBottleRepository.AddAsync(wineBottle));
    }

    public async Task<WineBottleResponseDto?> GetWineBottleByIdAsync(Guid id)
    {
        var wineBottle = await _wineBottleRepository.GetByIdAsync(id);
        if (wineBottle == null)
        {
            throw new Exception("Wine bottle not found.");
        }

        return _mapper.Map<WineBottleResponseDto>(wineBottle);
    }

    public async Task<WineBottleResponseDto> UpdateWineBottleAsync(WineBottleUpdateDto wineBottleDto)
    {
        var wineBottle = _mapper.Map<Models.WineBottle.WineBottle>(wineBottleDto);

        return _mapper.Map<WineBottleResponseDto>(await _wineBottleRepository.UpdateAsync(wineBottle));
    }

    public async Task DeleteWineBottleAsync(Guid id)
    {
        await _wineBottleRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<WineBottleResponseDto>?> FindWineBottlesAsync(WineBottleFilterDto wineBottleFilterDto)
    {
        return _mapper.Map<IEnumerable<WineBottleResponseDto>>(await _wineBottleRepository.FindAsync(wineBottleFilterDto));
    }

    private void CreateId(Models.WineBottle.WineBottle wineBottle)
    {
        wineBottle.Id = Guid.NewGuid();
    }
}
