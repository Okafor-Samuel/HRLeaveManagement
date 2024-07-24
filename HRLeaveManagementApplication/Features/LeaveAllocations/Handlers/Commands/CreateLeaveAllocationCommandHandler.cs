using AutoMapper;
using HRLeaveManagementApplication.DTOs.LeaveAllocation.Validators;
using HRLeaveManagementApplication.DTOs.LeaveRequest.Validators;
using HRLeaveManagementApplication.Exceptions;
using HRLeaveManagementApplication.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagementApplication.Contracts.Persistence;
using HRLeaveManagementApplication.Responses;
using HRLeaveManagementDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
 
        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                throw new ValidationException(validationResult);
            }
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveAllocation.Id;
            return response;
        }
    }
}
