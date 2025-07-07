using FuarPrint.Core.DataAccess.EntityFramework;
using FuarPrint.DataAccess.Abstract;
using FuarPrint.DataAccess.Data;
using FuarPrint.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.DataAccess.Concrete.EfEntityFramework
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage, FuarDbContext>, IProductImageDal
    {
        public EfProductImageDal(FuarDbContext context) : base(context)
        {
        }
    }
}
