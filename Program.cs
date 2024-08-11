using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WineManager.Data;
using WineManager.Repositories;
using WineManager.Repositories.WineBottle;
using WineManager.Repositories.WineMaker;
using WineManager.Services.WineBottle;
using WineManager.Services.WineMaker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<InMemoryDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb")); 
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); 
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWineMakerService, WineMakerService>();
builder.Services.AddScoped<IWineBottleService, WineBottleService>();
builder.Services.AddScoped<IWineMakerRepository, WineMakerRepository>();
builder.Services.AddScoped<IWineBottleRepository, WineBottleRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    var dbContext = serviceScope?.ServiceProvider.GetRequiredService<InMemoryDbContext>();
    DbInitializer.InitializeAsync(dbContext).Wait();
}

app.Run();
