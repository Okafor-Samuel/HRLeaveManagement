using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationDtoValidator()
        {
            RuleFor(p => p.Period)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
              

            RuleFor(p => p.NumberOfDays)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");


            RuleFor(p => p.LeaveTypeId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
               .MustAsync
        }
    }
}
