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
    public class CustomerService
        : BaseService<CustomerDTO, Customer, CustomerDTO>, ICustomerService
    {
        public CustomerService(IMapper mapper, AppDBContext dbContext) : base(mapper, dbContext)
        {
        }
    }
}
