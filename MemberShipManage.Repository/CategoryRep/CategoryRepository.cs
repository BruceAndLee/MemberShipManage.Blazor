using MemberShipManage.Infrastructurer;
using MemberShipManage.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.CategoryRep
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        {

        }

        public List<Category> GetCategoryList()
        {
            return Get().ToList();
        }

        public Category GetCategory(int categoryID)
        {
            return GetSingle(d => d.Id == categoryID);
        }
    }
}

