using FuarPrint.Entities.Models.Category;
using FuarPrint.Entities.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Abstract
{
    public interface IProductService
    {

        Task<List<ProductGetDto>> GetAllAsync();
        Task<ProductGetDto> GetByIdAsync(int id);
        Task AddAsync(ProductCreateDto dto);
        Task UpdateAsync(int id, ProductUpdateDto dto);
        Task DeleteAsync(int id);
        Task<List<ProductGetDto>> GetByCategoryIdAsync(int categoryId);
        Task<List<ProductGetDto>> GetByColorIdAsync(int colorId);


    }
}
