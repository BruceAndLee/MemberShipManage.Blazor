using System;
using System.Collections.Generic;
using System.Text;
using MemberShipManage.Infrastructurer.Pagination;
using MemberShipManage.Server.Models;
using MemberShipManage.Shared.CustomerDTO;

namespace MemberShipManage.Service.CustomerSvc
{
    public interface ICustomerService
    {
        List<Customer> GetCustomerList();
        void CreateCustomer(Customer customer);
        CustomerGetResponse GetCustomerList(CustomerGetRequest request);
    }
}
