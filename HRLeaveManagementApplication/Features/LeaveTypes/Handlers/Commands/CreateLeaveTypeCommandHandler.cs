using AutoMapper;
using HRLeaveManagementApplication.DTOs.LeaveType.Validators;
using HRLeaveManagementApplication.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagementApplication.Persistence.Contracts;
using HRLeaveManagementDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveTypes.Handlers.Commands
{
    internal class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveType, IMapper mapper)
        {
            _leaveTypeRepository = leaveType;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);
            if (validationResult.IsValid == false) 
            {
                throw new Exception();
            }
            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            return leaveType.Id;
        }
    }
}
