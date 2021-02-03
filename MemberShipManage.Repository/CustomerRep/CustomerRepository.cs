using Microsoft.Data.SqlClient;
using System;
using System.Data;
using MemberShipManage.Infrastructurer;
using MemberShipManage.Infrastructurer.Pagination;
using MemberShipManage.Server.Models;
using MemberShipManage.Shared.CustomerDTO;

namespace MemberShipManage.Repository.CustomerRep
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        {

        }

        public CustomPagedList<CustomerDetailEntity> GetCustomerList(CustomerGetRequest request)
        {
            var sqlScript = DBScriptManager.GetScript(GetType(), "GetCustomerList");

            var paramTotal = new SqlParameter("@TotalCount", SqlDbType.Int);
            paramTotal.Direction = ParameterDirection.Output;

            var paramUserNo = new SqlParameter("@UserNo", SqlDbType.VarChar, 25);
            paramUserNo.Value = request.UserNo ?? string.Empty;

            var paramName = new SqlParameter("@Name", SqlDbType.NVarChar, 20);
            paramName.Value = request.Name ?? string.Empty;

            var paramSex = new SqlParameter("@Sex", SqlDbType.Int);
            if (!request.Sex.HasValue)
            {
                paramSex.Value = DBNull.Value;
            }
            else
            {
                paramSex.Value = request.Sex;
            }

            var paramPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int);
            paramPageIndex.Value = request.PageIndex - 1;

            var paramPageSize = new SqlParameter("@PageSize", SqlDbType.Int);
            paramPageSize.Value = request.PageSize;

            var customerList = ExecuteSqlQuery<CustomerDetailEntity>(sqlScript, new SqlParameter[]
            {
                paramUserNo,
                paramName,
                paramSex,
                paramPageIndex,
                paramPageSize,
                paramTotal
            });

            return new CustomPagedList<CustomerDetailEntity>(customerList, request.PageIndex, request.PageSize, Convert.ToInt32(paramTotal.Value));
        }
    }
}
