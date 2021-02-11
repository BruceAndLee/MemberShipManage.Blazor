using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MemberShipManage.Server.Filters
{
    public class UserCreditFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("user_credit")
                || string.IsNullOrEmpty(context.HttpContext.Request.Headers["user_credit"]))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult("user credit is required.");
            }

            base.OnActionExecuting(context);
        }
    }
}
