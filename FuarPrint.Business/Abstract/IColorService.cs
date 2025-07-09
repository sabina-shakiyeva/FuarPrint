using FuarPrint.Entities.Models.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Abstract
{
    public interface IColorService
    {
        Task AddAsync(ColorCreateDto dto);
        Task<List<ColorGetDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
