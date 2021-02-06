using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberShipManage.Server.Models;
using MemberShipManage.Shared.CustomerDTO;

namespace MemberShipManage.Server.EntityMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerCreateRequest, Customer>();
            CreateMap<CustomerUpdateRequest, CustomerDetailEntity>();
        }
    }
}
