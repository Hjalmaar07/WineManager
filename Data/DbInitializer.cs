using WineManager.Models.WineBottle;
using WineManager.Models.WineMaker;

namespace WineManager.Data;

public class DbInitializer
{
    public static async Task InitializeAsync(InMemoryDbContext context)
    {
        var wineMakers = new List<WineMaker>();

        for (int i = 1; i <= 4; i++)
        {
            var id = Guid.NewGuid();
            var wineMaker = new WineMaker
            {
                Id = id,
                Name = $"WineMaker {new Random().Next(1, 20)}",
                Address = $"Address {new Random().Next(1, 20)}",
                WineBottles = GenerateWineBottles(id)
            };

            wineMakers.Add(wineMaker);
        }

        context.WineMaker.AddRange(wineMakers);
        await context.SaveChangesAsync();
    }

    private static IEnumerable<WineBottle> GenerateWineBottles(Guid winemakerId)
    {
        var styles = Enum.GetValues(typeof(StyleEnum)).Cast<StyleEnum>().ToList();
        var tastes = Enum.GetValues(typeof(TasteEnum)).Cast<TasteEnum>().ToList();
        var wineBottles = new List<WineBottle>();

        for (int i = 1; i <= 3; i++)
        {
            var wineBottle = new WineBottle
            {
                Id = Guid.NewGuid(),
                WinemakerId = winemakerId,
                Name = $"WineBottle {new Random().Next(1, 20)}",
                Year = DateTime.Now.Year - i,
                Size = $"{750 + new Random().Next(1, 20)}ml",
                CountInCellar = new Random().Next(1, 20) * 10,
                Style = styles[new Random().Next(0, 2)],
                Taste = tastes[new Random().Next(0, 4)],
                Description = $"Description for WineBottle {new Random().Next(1, 20)}",
                FoodPairing = $"FoodPairing {new Random().Next(1, 20)}",
                Link = $"http://example.com/winebottle{new Random().Next(1, 20)}",
                Image = $"ImageURL{new Random().Next(1, 20)}"
            };

            wineBottles.Add(wineBottle);
        }

        return wineBottles;
    }
}
