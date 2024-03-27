using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entity;
using DTO.EntityDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MenuSerice : BaseService<MenuDTO, Menu, MenuDTO>, IMenuSerice
    {
        public MenuSerice(IMapper mapper, AppDBContext dbContext) : base(mapper, dbContext)
        {
        }

        public IEnumerable<MenuDTO> GetAllInclude()
        {
            var ent = _dBSet.Include(x => x.Category).ToList();

            var rsdto = _mapper.Map<IEnumerable<MenuDTO>>(ent);
            return rsdto;
        }
    }
}
