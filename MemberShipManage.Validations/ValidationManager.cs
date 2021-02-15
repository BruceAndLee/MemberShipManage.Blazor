using FluentValidation;
using MemberShipManage.Shared.CustomerDTO;
using MemberShipManage.Validation;
using Microsoft.Extensions.DependencyInjection;

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
