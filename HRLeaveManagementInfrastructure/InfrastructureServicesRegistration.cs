using HRLeaveManagementApplication.Contracts.Infrastructure;
using HRLeaveManagementApplication.Models;
using HRLeaveManagementInfrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementInfrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
