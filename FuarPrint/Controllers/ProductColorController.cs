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
    public class ProductColorController : ControllerBase
    {
        private readonly IProductColorService _service;

        public ProductColorController(IProductColorService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductColorCreateDto dto)
        {
            await _service.AddAsync(dto);
            return Ok("Color assigned to product.");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int productId, [FromQuery] int colorId)
        {
            await _service.DeleteAsync(productId, colorId);
            return Ok("Color removed from product.");
        }
    }
}
