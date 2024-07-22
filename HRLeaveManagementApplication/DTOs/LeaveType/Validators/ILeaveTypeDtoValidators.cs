using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidators : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidators()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is requires")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p=> p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1. ")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue} characters.");
        }
    }
}
