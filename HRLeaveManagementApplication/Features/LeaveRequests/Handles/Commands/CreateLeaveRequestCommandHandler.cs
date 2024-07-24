using AutoMapper;
using HRLeaveManagementApplication.DTOs.LeaveRequest.Validators;
using HRLeaveManagementApplication.Exceptions;
using HRLeaveManagementApplication.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagementApplication.Contracts.Persistence;
using HRLeaveManagementApplication.Responses;
using HRLeaveManagementDomain;
using MediatR;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using HRLeaveManagementApplication.Contracts.Infrastructure;
using HRLeaveManagementApplication.Models;
using System;

namespace HRLeaveManagementApplication.Features.LeaveRequests.Handles.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper,
            IEmailSender emailSender,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
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

            var email = new Email
            {
                To = "employee@org.com",
                Body = $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} " +
                $"has been submitted successfuly. ",
                Subject = "Submission of Leave Requesr"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception e) 
            {
                //Handle exception
            }


            return response;
        }
    }
}
