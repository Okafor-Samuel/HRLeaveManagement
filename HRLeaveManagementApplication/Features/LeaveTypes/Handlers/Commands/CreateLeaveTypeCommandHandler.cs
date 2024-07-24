using AutoMapper;
using HRLeaveManagementApplication.DTOs.LeaveType.Validators;
using HRLeaveManagementApplication.Exceptions;
using HRLeaveManagementApplication.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagementApplication.Persistence.Contracts;
using HRLeaveManagementApplication.Responses;
using HRLeaveManagementDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveTypes.Handlers.Commands
{
    internal class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveType, IMapper mapper)
        {
            _leaveTypeRepository = leaveType;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);
            if (validationResult.IsValid == false) 
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                throw new ValidationException(validationResult);
            }
            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveType.Id;
            return response;
        }
    }
}
