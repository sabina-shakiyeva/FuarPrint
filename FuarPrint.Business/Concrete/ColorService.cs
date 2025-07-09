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
    public class ColorService:IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorService(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public async Task AddAsync(ColorCreateDto dto)
        {
            var color=new Color { Name = dto.Name };

            await _colorDal.Add(color);

        }
        public async Task<List<ColorGetDto>> GetAllAsync()
        {
            var colors=await _colorDal.GetAllAsync();
            return colors.Select(c=>new ColorGetDto
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
        }

        public async Task DeleteAsync(int id)
        {
            var color=await _colorDal.GetByIdAsync(id);
            if (color != null)
            {
                await _colorDal.Delete(color);
            }
        }
           

    }
}
