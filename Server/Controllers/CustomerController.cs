using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MemberShipManage.Infrastructurer.Pagination;
using MemberShipManage.Server.Models;
using MemberShipManage.Service.CustomerSvc;
using MemberShipManage.Shared.CustomerDTO;

namespace MemberShipManage.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;
        public CustomerController(
            ICustomerService customerService,
            IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }
        [HttpGet("get/all")]
        public IEnumerable<Customer> GetAllCustomerList()
        {
            return customerService.GetCustomerList();
        }

        [HttpPost("create")]
        public void CreateCustomer([FromBody]CustomerCreateRequest customerRequest)
        {
            var customer = mapper.Map<Customer>(customerRequest);
            customerService.CreateCustomer(customer);
        }

        [HttpGet("get")]
        public CustomerGetResponse GetCustomerList([FromQuery]CustomerGetRequest request)
        {
            return customerService.GetCustomerList(request);
        }
    }
}
