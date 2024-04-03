using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entity;
using DTO.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SocialMediaService
        : BaseService<SocialMediaDTO, SocialMedia, SocialMediaDTO>, ISocialMediaService
    {
        public SocialMediaService(IMapper mapper, AppDBContext dbContext) : base(mapper, dbContext)
        {
        }
    }
}
