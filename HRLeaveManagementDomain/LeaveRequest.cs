using HRLeaveManagementDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementDomain
{
    public class LeaveRequest : BaseDomainEntity
    {
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool? Cancelled { get; set; }
    }
}
