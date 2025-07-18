using FuarPrint.Business.Abstract;
using FuarPrint.DataAccess.Abstract;
using FuarPrint.DataAccess.Concrete.EfEntityFramework;
using FuarPrint.Entities.Concrete;
using FuarPrint.Entities.Models.Category;
using FuarPrint.Entities.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IFileService _fileService;
        private readonly IProductImageDal _productImageDal;
        private readonly IProductColorDal _productColorDal;



        public ProductService(IProductDal productDal, IFileService fileService, IProductImageDal productImageDal, IProductColorDal productColorDal)
        {
            _productDal = productDal;
            _fileService = fileService;
            _productImageDal = productImageDal;
            _productColorDal = productColorDal;
        }

        public async Task AddAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                IsActive = dto.IsActive
            };

            await _productDal.Add(product);

 
            if (dto.ImageIds != null && dto.ImageIds.Any())
            {
                foreach (var imageId in dto.ImageIds)
                {
                    var image = await _productImageDal.GetByIdAsync(imageId);
                    if (image != null)
                    {
                        image.ProductId = product.Id;
                        await _productImageDal.Update(image);
                    }
                }
            }

           
            if (dto.ColorIds != null && dto.ColorIds.Any())
            {
                foreach (var colorId in dto.ColorIds)
                {
                    var productColor = new ProductColor
                    {
                        ProductId = product.Id,
                        ColorId = colorId
                    };
                    await _productColorDal.Add(productColor);
                }
            }
        }


        public async Task DeleteAsync(int id)
        {
            var product = await _productDal.GetByIdAsync(id);
            if (product != null)
            {
                await _productDal.Delete(product);
            }
        }

        public async Task<List<ProductGetDto>> GetAllAsync()
        {
            var products = await _productDal.GetAllWithIncludesAsync();
            return products.Select(p => new ProductGetDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name,
                IsActive = p.IsActive,
                ImageUrls = p.ProductImages.Select(i => i.ImageUrl).ToList(),
                ColorNames = p.ProductColors.Select(c => c.Color.Name).ToList()
            }).ToList();
        }


        public async Task<ProductGetDto> GetByIdAsync(int id)
        {
            var p = await _productDal.GetByIdWithIncludesAsync(id);
            if (p == null) return null;

            return new ProductGetDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name,
                IsActive = p.IsActive,
                ImageUrls = p.ProductImages.Select(i => i.ImageUrl).ToList(),
                ColorNames = p.ProductColors.Select(c => c.Color.Name).ToList()
            };
        }


        public async Task UpdateAsync(int id, ProductUpdateDto dto)
        {
            var product = await _productDal.GetByIdWithIncludesAsync(id);
            if (product == null) return;

            if (dto.Name != null) product.Name = dto.Name;
            if (dto.Description != null) product.Description = dto.Description;
            if (dto.Price.HasValue) product.Price = dto.Price.Value;
            if (dto.CategoryId.HasValue) product.CategoryId = dto.CategoryId.Value;
            if (dto.IsActive.HasValue) product.IsActive = dto.IsActive.Value;

            await _productDal.Update(product);

            if (dto.ImageIds != null)
            {
                var allImages = await _productImageDal.GetAllAsync();
                var currentImages = allImages.Where(i => i.ProductId == product.Id).ToList();

           
                foreach (var img in currentImages)
                {
                    img.ProductId = 0;
                    await _productImageDal.Update(img);
                }

                foreach (var imageId in dto.ImageIds)
                {
                    var img = await _productImageDal.GetByIdAsync(imageId);
                    if (img != null)
                    {
                        img.ProductId = product.Id;
                        await _productImageDal.Update(img);
                    }
                }
            }

            if (dto.ColorIds != null)
            {
                var existing = await _productColorDal.GetAllAsync();
                var currentColors = existing.Where(pc => pc.ProductId == product.Id).ToList();

                foreach (var pc in currentColors)
                {
                    await _productColorDal.Delete(pc);
                }

                foreach (var colorId in dto.ColorIds)
                {
                    await _productColorDal.Add(new ProductColor
                    {
                        ProductId = product.Id,
                        ColorId = colorId
                    });
                }
            }
        }
        public async Task<List<ProductGetDto>> GetByColorIdAsync(int colorId)
        {
            var products = await _productDal.GetAllWithIncludesAsync();

            var filtered = products
                .Where(p => p.ProductColors.Any(pc => pc.ColorId == colorId))
                .ToList();

            return filtered.Select(p => new ProductGetDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name,
                IsActive = p.IsActive,
                ImageUrls = p.ProductImages.Select(i => i.ImageUrl).ToList(),
                ColorNames = p.ProductColors.Select(c => c.Color.Name).ToList()
            }).ToList();
        }




        public async Task<List<ProductGetDto>> GetByCategoryIdAsync(int categoryId)
        {
            var products = await _productDal.GetAllWithIncludesAsync();
            var filtered = products.Where(p => p.CategoryId == categoryId).ToList();

            return filtered.Select(p => new ProductGetDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name,
                IsActive = p.IsActive,
                ImageUrls = p.ProductImages.Select(i => i.ImageUrl).ToList(),
                ColorNames = p.ProductColors.Select(c => c.Color.Name).ToList()
            }).ToList();
        }


    }
}
