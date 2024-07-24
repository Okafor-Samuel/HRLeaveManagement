using FluentValidation;
using HRLeaveManagementApplication.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
           _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
        }
    }
}
