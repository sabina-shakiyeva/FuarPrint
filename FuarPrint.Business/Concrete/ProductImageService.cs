using FuarPrint.Business.Abstract;
using FuarPrint.DataAccess.Abstract;
using FuarPrint.Entities.Concrete;
using FuarPrint.Entities.Models.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Concrete
{
    public class ProductImageService: IProductImageService
    {
        private readonly IProductImageDal _productImageDal;
        private readonly IFileService _fileService;

        public ProductImageService(IProductImageDal productImageDal, IFileService fileService)
        {
            _productImageDal = productImageDal;
            _fileService = fileService;
        }


        public async Task AddAsync(ProductImageCreateDto dto)
        {
            var imageUrl = await _fileService.UploadFileAsync(dto.Image);

            var entity = new ProductImage
            {
                ProductId = dto.ProductId,
                ImageUrl = imageUrl
            };

            await _productImageDal.Add(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _productImageDal.GetByIdAsync(id);
            if (entity != null)
            {
                await _productImageDal.Delete(entity);
            }
        }

    }
}
