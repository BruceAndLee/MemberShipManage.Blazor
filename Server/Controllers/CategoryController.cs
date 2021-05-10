using MemberShipManage.Server.Models;
using MemberShipManage.Service.CategorySvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberShipManage.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("get/all")]
        public IEnumerable<Category> GetCategoryList()
        {
            return this.categoryService.GetCategoryList();
        }
    }
}
