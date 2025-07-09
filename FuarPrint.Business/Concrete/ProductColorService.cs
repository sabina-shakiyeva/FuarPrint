using FuarPrint.Business.Abstract;
using FuarPrint.DataAccess.Abstract;
using FuarPrint.Entities.Concrete;
using FuarPrint.Entities.Models.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Concrete
{
    public class ProductColorService : IProductColorService
    {
        private readonly IProductColorDal _productColorDal;

        public ProductColorService(IProductColorDal productColorDal)
        {
            _productColorDal = productColorDal;
        }

        public async Task AddAsync(ProductColorCreateDto dto)
        {
            bool exists = await _productColorDal.ExistsAsync(dto.ProductId, dto.ColorId);

            if (!exists)
            {
                var entity = new ProductColor
                {
                    ProductId = dto.ProductId,
                    ColorId = dto.ColorId
                };
                await _productColorDal.Add(entity);
            }
        }

        public async Task DeleteAsync(int productId, int colorId)
        {
            var entity = await _productColorDal.GetByCompositeKeyAsync(productId, colorId);
            if (entity != null)
            {
                await _productColorDal.Delete(entity);
            }
        }
    }
}
