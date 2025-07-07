using FuarPrint.Entities.Concrete;
using FuarPrint.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task AddAsync(CategoryDto categoryDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(CategoryDto categoryDto);
    }
}
