using HRLeaveManagementApplication.DTOs.Common;
using HRLeaveManagementDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.DTOs.LeaveRequest
{
    public class LeaveRequestDto : BaseDto
    {
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool? Cancelled { get; set; }
    }
}
