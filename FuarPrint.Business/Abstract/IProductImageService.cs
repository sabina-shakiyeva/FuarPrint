using FuarPrint.Entities.Models.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Abstract
{
    public interface IProductImageService
    {
        Task AddAsync(ProductImageCreateDto dto);
        Task DeleteAsync(int id);
    }
}
