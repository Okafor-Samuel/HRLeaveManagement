using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeComand : IRequest
    {
        public int Id { get; set; }
    }
}
