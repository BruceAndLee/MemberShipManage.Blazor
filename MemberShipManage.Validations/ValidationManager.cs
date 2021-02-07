using FluentValidation;
using MemberShipManage.Shared.CustomerDTO;
using MemberShipManage.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Validations
{
    public static class ValidationManager
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CustomerCreateRequest>, CustomerCreateRequestValidator>();
            services.AddTransient<IValidator<CustomerUpdateRequest>, CustomerUpdateRequestValidator>();
        }
    }
}
