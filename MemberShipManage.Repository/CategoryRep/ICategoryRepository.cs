using MemberShipManage.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.CategoryRep
{
    public interface ICategoryRepository
    {
        List<Category> GetCategoryList();

        Category GetCategory(int categoryID);
    }
}
