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
    public class EfCategoryDal : EfEntityRepositoryBase<Category, FuarDbContext>, ICategoryDal
    {
        public EfCategoryDal(FuarDbContext context) : base(context)
        {
        }
    }
}
