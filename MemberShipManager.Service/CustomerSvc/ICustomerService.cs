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
        Customer GetCustomerByKey(int customerId);
        List<Customer> GetCustomerList();
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        CustomerGetResponse GetCustomerList(CustomerGetRequest request);
    }
}
