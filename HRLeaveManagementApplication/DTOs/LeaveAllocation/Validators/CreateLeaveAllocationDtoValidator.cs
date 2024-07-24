using FluentValidation;
using HRLeaveManagementApplication.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
           _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));
        }
    }
}
