using AutoMapper;
using HRLeaveManagementApplication.DTOs.LeaveAllocation;
using HRLeaveManagementApplication.DTOs.LeaveRequest;
using HRLeaveManagementApplication.DTOs.LeaveType;
using HRLeaveManagementDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementApplication.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}
