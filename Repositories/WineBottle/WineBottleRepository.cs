using Microsoft.EntityFrameworkCore;
using WineManager.Data;
using WineManager.Dto.WineBottle;

namespace WineManager.Repositories.WineBottle;

public class WineBottleRepository : Repository<Models.WineBottle.WineBottle>, IWineBottleRepository
{
    private IQueryable<Models.WineBottle.WineBottle> _filteredWineBottles;
    private WineBottleFilterDto _filter;

    public WineBottleRepository(InMemoryDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Models.WineBottle.WineBottle>?> FindAsync(WineBottleFilterDto wineBottleFilterDto)
    {
        _filter = wineBottleFilterDto;
        _filteredWineBottles = _dbSet;

        FilterWineBottleByName();
        FilterWineBottleByYear();
        FilterWineBottleBySize();
        FilterWineBottleByCountInCellar();
        FilterWineBottleByStyle();
        FilterWineBottleByTaste();
        FilterWineBottleByDescription();
        FilterWineBottleByFoodPairing();

        return await _filteredWineBottles.ToListAsync();
    }

    private void FilterWineBottleByName()
    {
        if (!string.IsNullOrEmpty(_filter.Name))
        {
            _filteredWineBottles = _filteredWineBottles.Where(x => x.Name != null &&
                x.Name.Contains(_filter.Name, StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void FilterWineBottleByYear()
    {
        if (!string.IsNullOrEmpty(_filter.Year.ToString()))
        {
            _filteredWineBottles = _filteredWineBottles.Where(x => 
                x.Year.ToString().Contains(_filter.Year.ToString(), StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void FilterWineBottleBySize()
    {
        if (!string.IsNullOrEmpty(_filter.Size))
        {
            _filteredWineBottles = _filteredWineBottles.Where(x => x.Size != null &&
                x.Size.Contains(_filter.Size, StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void FilterWineBottleByCountInCellar()
    {
        if (!string.IsNullOrEmpty(_filter.CountInCellar.ToString()))
        {
            _filteredWineBottles = _filteredWineBottles.Where(x => 
                x.CountInCellar.ToString().Contains(_filter.CountInCellar.ToString(), StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void FilterWineBottleByStyle()
    {
        if (!string.IsNullOrEmpty(_filter.Style.ToString()))
        {
            _filteredWineBottles = _filteredWineBottles.Where(x => 
                x.Style.ToString().Contains(_filter.Style.ToString(), StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void FilterWineBottleByTaste()
    {
        if (!string.IsNullOrEmpty(_filter.Taste.ToString()))
        {
            _filteredWineBottles = _filteredWineBottles.Where(x =>
                x.Taste.ToString().Contains(_filter.Taste.ToString(), StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void FilterWineBottleByDescription()
    {
        if (!string.IsNullOrEmpty(_filter.Description))
        {
            _filteredWineBottles = _filteredWineBottles.Where(x => x.Description != null &&
                x.Description.Contains(_filter.Description, StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void FilterWineBottleByFoodPairing()
    {
        if (!string.IsNullOrEmpty(_filter.FoodPairing))
        {
            _filteredWineBottles = _filteredWineBottles.Where(x => x.FoodPairing != null &&
                x.FoodPairing.Contains(_filter.FoodPairing, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
