using Microsoft.AspNetCore.Mvc;
using WineManager.Dto.WineMaker;
using WineManager.Services.WineMaker;

namespace WineManager.Controllers;

[ApiController]
public class WineMakerController : ControllerBase
{
    private readonly IWineMakerService _wineMakerService;

    public WineMakerController(IWineMakerService winemakerService)
    {
        _wineMakerService = winemakerService;
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<IActionResult> Post(WineMakerCreateDto winemakerDto)
    {
        try
        {
            return CreatedAtAction(nameof(Post), await _wineMakerService.CreateWineMakerAsync(winemakerDto));
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
            var wineMaker = Ok(await _wineMakerService.GetWineMakerByIdAsync(id));
            if (wineMaker == null)
            {
                return NotFound();
            }
            return Ok(wineMaker);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    [Route("[controller]")]
    public async Task<IActionResult> Patch(WineMakerUpdateDto winemakerDto)
    {
        try
        {
            return Ok(await _wineMakerService.UpdateWineMakerAsync(winemakerDto));
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
            await _wineMakerService.DeleteWineBottleAsync(id);
            return Ok();
        }
        catch (Exception ex) 
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<IActionResult> Find([FromQuery] WineMakerFilterDto wineMakerFilter)
    {
        try
        {
            return Ok(await _wineMakerService.FindWineMakersAsync(wineMakerFilter));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
