using HRLeaveManagementApplication.DTOs.LeaveAllocation;
using HRLeaveManagementApplication.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
