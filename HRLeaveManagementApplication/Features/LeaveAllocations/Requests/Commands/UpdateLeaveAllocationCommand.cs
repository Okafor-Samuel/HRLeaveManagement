using HRLeaveManagementApplication.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand : IRequest<int>
    {
        public UpdateLeaveAllocationDto updateLeaveAllocationDto { get; set; }
    }
}
