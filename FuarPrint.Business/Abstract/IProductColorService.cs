using FuarPrint.Entities.Models.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Abstract
{
    public interface IProductColorService
    {
        Task AddAsync(ProductColorCreateDto dto);
        Task DeleteAsync(int productId, int colorId);
    }
}
