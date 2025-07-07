//using FuarPrint.Business.Abstract;
//using FuarPrint.DataAccess.Abstract;
//using FuarPrint.Entities.Concrete;
//using FuarPrint.Entities.Models;
//using FuarPrint.Entities.Models.Category;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FuarPrint.Business.Concrete
//{
//    public class CategoryService : ICategoryService
//    {
//        private readonly ICategoryDal _categoryDal;
//        private readonly IFileService _fileService;

//        public CategoryService(ICategoryDal categoryDal, IFileService fileService)
//        {
//            _categoryDal = categoryDal;
//            _fileService = fileService;
//        }

        
//        public async Task AddAsync(CategoryCreateDto categoryDto)
//        {
//            string imageUrl = null;
//            if (categoryDto.ImageUrl != null)
//                imageUrl = await _fileService.UploadFileAsync(categoryDto.ImageUrl);

//            var category = new Category
//            {
//                Name = categoryDto.Name,
//                ImageUrl = imageUrl
//            };

//            await _categoryDal.Add(category);
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var category=await _categoryDal.GetByIdAsync(id);
//            if (category != null) return;

//            await _categoryDal.Delete(category);
//        }

//        public async Task<List<CategoryDto>> GetAllAsync()
//        {
//            var categories=await _categoryDal.GetAllAsync();
//            return categories.Select(c=> new CategoryDto
//            {
//                Id= c.Id,
//                Name= c.Name,

//            }).ToList();
//        }

//        public async Task<CategoryDto> GetByIdAsync(int id)
//        {
//           var category=await _categoryDal.GetByIdAsync(id);
//            if (category == null) return null;
//            return new CategoryDto
//            {
//                Id = category.Id,
//                Name = category.Name,
//            };
//        }

//        public async Task UpdateAsync(CategoryDto categoryDto)
//        {
//            var category = await _categoryDal.GetByIdAsync(categoryDto.Id);
//            if (category == null) return;
//            category.Name = categoryDto.Name;
//            await _categoryDal.Update(category);
//        }
//    }
//}
