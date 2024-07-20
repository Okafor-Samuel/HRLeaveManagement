using HRLeaveManagementApplication.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.DTOs.LeaveType
{
    public class CreateLeaveTypeDto 
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
