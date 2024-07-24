using HRLeaveManagementApplication.DTOs.LeaveType;
using HRLeaveManagementApplication.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }

    }
}
