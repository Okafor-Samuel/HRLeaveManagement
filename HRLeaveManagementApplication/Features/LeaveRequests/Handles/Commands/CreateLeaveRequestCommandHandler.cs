using AutoMapper;
using HRLeaveManagementApplication.DTOs.LeaveRequest.Validators;
using HRLeaveManagementApplication.Exceptions;
using HRLeaveManagementApplication.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagementApplication.Persistence.Contracts;
using HRLeaveManagementApplication.Responses;
using HRLeaveManagementDomain;
using MediatR;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveRequests.Handles.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                throw new ValidationException(validationResult);
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveRequest.Id;
            return response;
        }
    }
}
