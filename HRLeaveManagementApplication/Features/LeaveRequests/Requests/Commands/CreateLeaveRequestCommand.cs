using HRLeaveManagementApplication.DTOs.LeaveRequest;
using HRLeaveManagementApplication.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }
    }
}
