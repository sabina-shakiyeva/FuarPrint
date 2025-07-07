using FuarPrint.Entities.Concrete;
using FuarPrint.Entities.Models;
using FuarPrint.Entities.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryGetDto>> GetAllAsync();
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task AddAsync(CategoryCreateDto categoryDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,CategoryUpdateDto categoryDto);
    }
}
