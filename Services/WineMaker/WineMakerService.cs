using AutoMapper;
using WineManager.Dto.WineMaker;
using WineManager.Repositories.WineMaker;

namespace WineManager.Services.WineMaker;

public class WineMakerService : IWineMakerService
{
    private readonly IMapper _mapper;
    private readonly IWineMakerRepository _wineMakerRepository;

    public WineMakerService(IMapper mapper, IWineMakerRepository wineMakerRepository)
    {
        _mapper = mapper;
        _wineMakerRepository = wineMakerRepository;
    }

    public async Task<WineMakerResponseDto> CreateWineMakerAsync(WineMakerCreateDto winemakerDto)
    {
        var wineMaker = _mapper.Map<Models.WineMaker.WineMaker>(winemakerDto);
        CreateId(wineMaker);

        return _mapper.Map<WineMakerResponseDto>(await _wineMakerRepository.AddAsync(wineMaker));
    }

    public async Task<WineMakerResponseDto?> GetWineMakerByIdAsync(Guid id)
    {
        var wineMaker = await _wineMakerRepository.GetByIdAsync(id);
        if(wineMaker == null)
        {
            throw new Exception("Wine maker not found.");
        }

        return _mapper.Map<WineMakerResponseDto>(wineMaker);
    }

    public async Task<WineMakerResponseDto> UpdateWineMakerAsync(WineMakerUpdateDto winemakerDto)
    {
        var wineMaker = _mapper.Map<Models.WineMaker.WineMaker>(winemakerDto);

        return _mapper.Map<WineMakerResponseDto>(await _wineMakerRepository.UpdateAsync(wineMaker));
    }

    public async Task DeleteWineBottleAsync(Guid id)
    {
        await _wineMakerRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<WineMakerResponseDto>?> FindWineMakersAsync(WineMakerFilterDto wineMakerFilterDto)
    {
        return _mapper.Map<IEnumerable<WineMakerResponseDto>>(await _wineMakerRepository.FindAsync(wineMakerFilterDto));
    }

    private void CreateId(Models.WineMaker.WineMaker wineMaker)
    {
        wineMaker.Id = Guid.NewGuid();
    }
}
