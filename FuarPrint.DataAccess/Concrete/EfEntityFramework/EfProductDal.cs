using FuarPrint.Core.DataAccess.EntityFramework;
using FuarPrint.DataAccess.Abstract;
using FuarPrint.DataAccess.Data;
using FuarPrint.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.DataAccess.Concrete.EfEntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, FuarDbContext>, IProductDal
    {
        private readonly FuarDbContext _context;
        public EfProductDal(FuarDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllWithIncludesAsync()
        {
            return await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductColors)
                    .ThenInclude(pc => pc.Color)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductColors)
                    .ThenInclude(pc => pc.Color)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
