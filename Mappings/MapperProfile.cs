using AutoMapper;
using WineManager.Dto.WineBottle;
using WineManager.Dto.WineMaker;
using WineManager.Models.WineBottle;
using WineManager.Models.WineMaker;

namespace WineManager.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<WineMakerCreateDto, WineMaker>();
        CreateMap<WineMakerUpdateDto, WineMaker>();
        CreateMap<WineMaker, WineMakerResponseDto>();
        CreateMap<WineBottleCreateDto, WineBottle>();
        CreateMap<WineBottleUpdateDto, WineBottle>();
        CreateMap<WineBottle, WineBottleResponseDto>();
    }
}
