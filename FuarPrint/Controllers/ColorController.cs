using FuarPrint.Business.Abstract;
using FuarPrint.Entities.Models.Color;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuarPrint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ColorCreateDto dto)
        {
            await _colorService.AddAsync(dto);
            return Ok("Color created.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var colors = await _colorService.GetAllAsync();
            return Ok(colors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _colorService.DeleteAsync(id);
            return Ok("Color deleted.");
        }
    }
}
