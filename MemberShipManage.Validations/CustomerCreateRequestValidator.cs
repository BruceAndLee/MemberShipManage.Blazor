﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using MemberShipManage.Shared.CustomerDTO;

namespace MemberShipManage.Validation
{
    public class CustomerCreateRequestValidator : AbstractValidator<CustomerCreateRequest>
    {
        public CustomerCreateRequestValidator()
        {
            RuleFor(x => x.UserNo)
                .NotNull()
                .NotEmpty()
                .MaximumLength(11);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.Sex)
                .NotNull()
                .InclusiveBetween(1, 2);

            RuleFor(x => x.ParentID)
               .GreaterThanOrEqualTo(0);
        }
    }
}
