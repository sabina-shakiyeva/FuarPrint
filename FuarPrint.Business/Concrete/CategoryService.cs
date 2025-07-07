using FuarPrint.Business.Abstract;
using FuarPrint.DataAccess.Abstract;
using FuarPrint.Entities.Concrete;
using FuarPrint.Entities.Models;
using FuarPrint.Entities.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IFileService _fileService;

        public CategoryService(ICategoryDal categoryDal, IFileService fileService)
        {
            _categoryDal = categoryDal;
            _fileService = fileService;
        }


        public async Task AddAsync(CategoryCreateDto categoryDto)
        {
            string imageUrl = null;
            if (categoryDto.ImageUrl != null)
                imageUrl = await _fileService.UploadFileAsync(categoryDto.ImageUrl);

            var category = new Category
            {
                Name = categoryDto.Name,
                ImageUrl = imageUrl
            };

            await _categoryDal.Add(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryDal.GetByIdAsync(id);
            if (category != null) return;

            await _categoryDal.Delete(category);
        }

        public async Task<List<CategoryGetDto>> GetAllAsync()
        {
            var categories = await _categoryDal.GetAllAsync();
            return categories.Select(c => new CategoryGetDto
            {
                Id = c.Id,
                Name = c.Name,
                ImageUrl=c.ImageUrl

            }).ToList();
        }

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            var category = await _categoryDal.GetByIdAsync(id);
            if (category == null) return null;
            return new CategoryGetDto
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl=category.ImageUrl
                
            };
        }

        public async Task UpdateAsync(int id,CategoryUpdateDto updateDto)
        {
            var category = await _categoryDal.GetByIdAsync(id);
            if (category == null) return;
            if(updateDto.Name!=null)
                category.Name = updateDto.Name;
            if (updateDto.ImageUrl!=null)
                category.ImageUrl=await _fileService.UploadFileAsync(updateDto.ImageUrl);
        
            await _categoryDal.Update(category);
        }
    }
}
