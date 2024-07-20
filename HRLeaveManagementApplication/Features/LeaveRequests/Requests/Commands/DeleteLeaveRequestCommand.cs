using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.Features.LeaveRequests.Requests.Commands
{
    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
