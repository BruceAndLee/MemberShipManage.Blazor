using MemberShipManage.Repository.CategoryRep;
using MemberShipManage.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.CategorySvc
{
    public class CategoryService: ICategoryService
    {
        ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<Category> GetCategoryList()
        {
            return categoryRepository.GetCategoryList();
        }

        public Category GetCategory(int categoryID)
        {
            return categoryRepository.GetCategory(categoryID);
        }
    }
}
