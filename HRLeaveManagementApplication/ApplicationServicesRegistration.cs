using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HRLeaveManagementApplication
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplication(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
