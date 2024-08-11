using WineManager.Dto.WineBottle;

namespace WineManager.Repositories.WineBottle;

public interface IWineBottleRepository : IRepository<Models.WineBottle.WineBottle>
{
    Task<IEnumerable<Models.WineBottle.WineBottle>?> FindAsync(WineBottleFilterDto wineBottleFilterDto);
}
