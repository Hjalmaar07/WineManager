using Microsoft.EntityFrameworkCore;
using WineManager.Data;
using WineManager.Dto.WineMaker;

namespace WineManager.Repositories.WineMaker;

public class WineMakerRepository : Repository<Models.WineMaker.WineMaker>, IWineMakerRepository
{
    private IQueryable<Models.WineMaker.WineMaker> _filteredWineMakers;
    private WineMakerFilterDto _filter;

    public WineMakerRepository(InMemoryDbContext context) : base(context)
    {
    }

    public override async Task<Models.WineMaker.WineMaker?> GetByIdAsync(Guid id)
    {
        return await _dbSet.Include(x => x.WineBottles).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Models.WineMaker.WineMaker>?> FindAsync(WineMakerFilterDto wineMakerFilterDto)
    {
        _filter = wineMakerFilterDto;
        _filteredWineMakers = _dbSet.Include(x => x.WineBottles);

        FilterWineMakerByName();
        FilterWineMakerByAddress();
        FilterWineBottles();

        return await _filteredWineMakers.ToListAsync();
    }

    private void FilterWineMakerByName()
    {
        if (!string.IsNullOrEmpty(_filter.Name))
        {
            _filteredWineMakers = _filteredWineMakers.Where(wm => wm.Name != null &&
                wm.Name.Contains(_filter.Name, StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void FilterWineMakerByAddress()
    {
        if (!string.IsNullOrEmpty(_filter.Address))
        {
            _filteredWineMakers = _filteredWineMakers.Where(wm => wm.Address != null &&
                wm.Address.Contains(_filter.Address, StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void FilterWineBottles()
    {
        if (_filter.WineBottle != null)
        {
            FilterWineMakerByWineBottleName();
            FilterWineMakerByWineBottleYear();
            FilterWineMakerByWineBottleSize();
            FilterWineMakerByWineBottleCountInCellar();
            FilterWineMakerByWineBottleStyle();
            FilterWineMakerByWineBottleTaste();
            FilterWineMakerByWineBottleDescription();
            FilterWineMakerByWineBottleFoodPairing();
        }
    }

    private void FilterWineMakerByWineBottleName()
    {
        if (!string.IsNullOrEmpty(_filter.WineBottle.Name))
        {
            var name = _filter.WineBottle.Name;
            _filteredWineMakers = _filteredWineMakers.Where(wm => wm.WineBottles != null &&
                wm.WineBottles.Any(wb => wb.Name != null && wb.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)));
        }
    }

    private void FilterWineMakerByWineBottleYear()
    {
        if (!string.IsNullOrEmpty(_filter.WineBottle.Year.ToString()))
        {
            var year = _filter.WineBottle.Year.ToString();
            _filteredWineMakers = _filteredWineMakers.Where(wm => wm.WineBottles != null &&
                wm.WineBottles.Any(wb => wb.Year.ToString().Contains(year, StringComparison.CurrentCultureIgnoreCase)));
        }
    }

    private void FilterWineMakerByWineBottleSize()
    {
        if (!string.IsNullOrEmpty(_filter.WineBottle.Size))
        {
            var size = _filter.WineBottle.Size;
            _filteredWineMakers = _filteredWineMakers.Where(wm => wm.WineBottles != null &&
                wm.WineBottles.Any(wb => wb.Size != null && wb.Size.Contains(size, StringComparison.CurrentCultureIgnoreCase)));
        }
    }

    private void FilterWineMakerByWineBottleCountInCellar()
    {
        var countInCellar = _filter.WineBottle.CountInCellar.ToString();
        if (!string.IsNullOrEmpty(countInCellar))
        {
            
            _filteredWineMakers = _filteredWineMakers.Where(wm => wm.WineBottles != null &&
                wm.WineBottles.Any(wb => wb.CountInCellar.ToString().Contains(countInCellar, StringComparison.CurrentCultureIgnoreCase)));
        }
    }

    private void FilterWineMakerByWineBottleStyle()
    {
        if (!string.IsNullOrEmpty(_filter.WineBottle.Style.ToString()))
        {
            var style = _filter.WineBottle.Style.ToString();
            _filteredWineMakers = _filteredWineMakers.Where(wm => wm.WineBottles != null &&
                wm.WineBottles.Any(wb => wb.Style.ToString().Contains(style, StringComparison.CurrentCultureIgnoreCase)));
        }
    }

    private void FilterWineMakerByWineBottleTaste()
    {
        if (!string.IsNullOrEmpty(_filter.WineBottle.Taste.ToString()))
        {
            var taste = _filter.WineBottle.Taste.ToString();
            _filteredWineMakers = _filteredWineMakers.Where(wm => wm.WineBottles != null &&
                wm.WineBottles.Any(wb => wb.Taste.ToString().Contains(taste, StringComparison.CurrentCultureIgnoreCase)));
        }
    }

    private void FilterWineMakerByWineBottleDescription()
    {
        if (!string.IsNullOrEmpty(_filter.WineBottle.Description))
        {
            var description = _filter.WineBottle.Description;
            _filteredWineMakers = _filteredWineMakers.Where(wm => wm.WineBottles != null &&
                wm.WineBottles.Any(wb => wb.Description != null && wb.Description.Contains(description, StringComparison.CurrentCultureIgnoreCase)));
        }
    }

    private void FilterWineMakerByWineBottleFoodPairing()
    {
        if (!string.IsNullOrEmpty(_filter.WineBottle.FoodPairing))
        {
            var foodPairing = _filter.WineBottle.FoodPairing;
            _filteredWineMakers = _filteredWineMakers.Where(wm => wm.WineBottles != null &&
                wm.WineBottles.Any(wb => wb.FoodPairing != null && wb.FoodPairing.Contains(foodPairing, StringComparison.CurrentCultureIgnoreCase)));
        }
    }
}
