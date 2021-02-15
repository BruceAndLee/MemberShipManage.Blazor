using System;
using System.Collections.Generic;
using System.Linq;
using MemberShipManage.Infrastructurer;
using MemberShipManage.Infrastructurer.Pagination;
using MemberShipManage.Repository.CustomerRep;
using MemberShipManage.Server.Models;
using MemberShipManage.Shared.CustomerDTO;

namespace MemberShipManage.Service.CustomerSvc
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository respository;
        public CustomerService(ICustomerRepository respository)
        {
            this.respository = respository;
        }

        public List<Customer> GetCustomerList()
        {
            return respository.Get().ToList();
        }

        public Customer GetCustomerByKey(int customerId)
        {
            return respository.Get(c => c.Id == customerId).FirstOrDefault();
        }

        public Customer GetCustomerByUserNo(string userNo)
        {
            return respository.Get(c => c.UserNo== userNo).FirstOrDefault();
        }

        public void CreateCustomer(Customer customer)
        {
            customer.InDate = DateTime.Now;
            customer.Status = true;
            customer.Password = new Cryptor().Encrypt(customer.Password.ToArray());
            respository.Add(customer);
            respository.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            respository.Update(customer);
            respository.SaveChanges();
        }

        public CustomerGetResponse GetCustomerList(CustomerGetRequest request)
        {
            var customerList = respository.GetCustomerList(request);
            return new CustomerGetResponse
            {
                TotalCount = customerList.TotalCount,
                TotalPages = customerList.TotalPages,
                CustomerDetailList = customerList
            };
        }
    }
}
