using FuarPrint.Core.DataAccess;
using FuarPrint.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.DataAccess.Abstract
{
    public interface IProductColorDal: IEntityRepository<ProductColor>
    {
        Task<bool> ExistsAsync(int productId, int colorId);
        Task<ProductColor?> GetByCompositeKeyAsync(int productId, int colorId);
    }
}
