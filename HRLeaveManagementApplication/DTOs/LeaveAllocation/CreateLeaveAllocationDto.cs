﻿using HRLeaveManagementApplication.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto 
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
