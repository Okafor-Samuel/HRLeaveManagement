using HRLeaveManagementApplication.DTOs.LeaveRequest;
using HRLeaveManagementApplication.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto UpdateLeaveRequestDto { get; set; }

        public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set;}
    }
}
