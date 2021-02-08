﻿using AutoMapper;
using MemberShipManage.Server.Models;
using MemberShipManage.Service.CustomerSvc;
using MemberShipManage.Shared.CustomerDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

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
        public HttpResponseMessage CreateCustomer([FromBody]CustomerCreateRequest customerRequest)
        {
            var customer = mapper.Map<Customer>(customerRequest);
            customerService.CreateCustomer(customer);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Authorize]
        [HttpPut("update")]
        public HttpResponseMessage UpdateCustomer([FromBody] CustomerUpdateRequest customerRequest)
        {
            var customer = customerService.GetCustomerByKey(customerRequest.ID);
            customer.Name = customerRequest.Name;
            customer.Sex = customerRequest.Sex;
            customer.ParentID = customerRequest.ParentID;
            customerService.UpdateCustomer(customer);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet("get")]
        public CustomerGetResponse GetCustomerList([FromQuery]CustomerGetRequest request)
        {
            return customerService.GetCustomerList(request);
        }
    }
}
