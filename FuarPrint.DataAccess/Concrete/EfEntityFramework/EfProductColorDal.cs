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
    public class EfProductColorDal : EfEntityRepositoryBase<ProductColor, FuarDbContext>, IProductColorDal
    {
        private readonly FuarDbContext _context;


        public EfProductColorDal(FuarDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> ExistsAsync(int productId, int colorId)
        {
            return await _context.ProductColors
                .AnyAsync(pc => pc.ProductId == productId && pc.ColorId == colorId);
        }

        public async Task<ProductColor?> GetByCompositeKeyAsync(int productId, int colorId)
        {
            return await _context.ProductColors
                .FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.ColorId == colorId);
        }
    }
}
