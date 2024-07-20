using HRLeaveManagementApplication.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApproval : BaseDto
    {
        public bool? Approved { get; set; }
    }
}
