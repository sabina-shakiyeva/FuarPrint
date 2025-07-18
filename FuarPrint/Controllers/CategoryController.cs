using FuarPrint.Business.Abstract;
using FuarPrint.Entities.Models;
using FuarPrint.Entities.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuarPrint.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result=await _categoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromForm] CategoryCreateDto categoryDto)
        {
            await _categoryService.AddAsync(categoryDto);
            return Ok("Category added successfully");
        }

        [HttpPut("{id}")]
        //[Authorize(Roles ="Admin")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(int id, [FromForm] CategoryUpdateDto categoryDto)
        {
            await _categoryService.UpdateAsync(id,categoryDto);
            return Ok(categoryDto);
        }
        

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok("Deleted successfully");
        }



    }
}
