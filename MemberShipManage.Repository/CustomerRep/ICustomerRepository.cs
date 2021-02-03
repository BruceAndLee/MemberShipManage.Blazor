using MemberShipManage.Infrastructurer.Pagination;
using MemberShipManage.Repository;
using MemberShipManage.Server.Models;
using MemberShipManage.Shared.CustomerDTO;

namespace MemberShipManage.Repository.CustomerRep
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        CustomPagedList<CustomerDetailEntity> GetCustomerList(CustomerGetRequest request);
    }
}
