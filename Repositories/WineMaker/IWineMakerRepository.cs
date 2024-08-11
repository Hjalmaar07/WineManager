using WineManager.Dto.WineMaker;

namespace WineManager.Repositories.WineMaker;

public interface IWineMakerRepository : IRepository<Models.WineMaker.WineMaker>
{
    new Task<Models.WineMaker.WineMaker?> GetByIdAsync(Guid id);
    Task<IEnumerable<Models.WineMaker.WineMaker>?> FindAsync(WineMakerFilterDto wineMakerFilterDto);
}
