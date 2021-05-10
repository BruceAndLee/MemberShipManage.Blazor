using MemberShipManage.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.CategorySvc
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();

        Category GetCategory(int categoryID);
    }
}
