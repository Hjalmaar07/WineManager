using Microsoft.AspNetCore.Mvc;
using WineManager.Dto.WineBottle;
using WineManager.Services.WineBottle;

namespace WineManager.Controllers;

[ApiController]
public class WineBottleController : ControllerBase
{
    private readonly IWineBottleService _wineBottleService;

    public WineBottleController(IWineBottleService wineBottleService)
    {
        _wineBottleService = wineBottleService;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<IActionResult> Post(WineBottleCreateDto wineBottleDto)
    {
        try
        {
            var createdWineBottle = await _wineBottleService.CreateWineBottleAsync(wineBottleDto);
            return CreatedAtAction(nameof(GetById), new { id = createdWineBottle.Id }, createdWineBottle);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("[controller]/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var wineBottle = await _wineBottleService.GetWineBottleByIdAsync(id);
            if (wineBottle == null)
            {
                return NotFound();
            }
            return Ok(wineBottle);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    [Route("[controller]")]
    public async Task<IActionResult> Patch(WineBottleUpdateDto wineBottleDto)
    {
        try
        {
            return Ok(await _wineBottleService.UpdateWineBottleAsync(wineBottleDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("[controller]/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _wineBottleService.DeleteWineBottleAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<IActionResult> Find([FromQuery] WineBottleFilterDto wineBottleFilter)
    {
        try
        {
            return Ok(await _wineBottleService.FindWineBottlesAsync(wineBottleFilter));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
