using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementDomain
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
