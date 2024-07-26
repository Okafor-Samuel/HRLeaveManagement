using HRLeaveManagementDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HRLeaveManagementPersistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Vacation",
                    CreatedBy = "System", // Set a default value for CreatedBy
                    DateCreated = DateTime.Now, // Set the current date and time
                    LastModifiedBy = "System", // Set a default value for LastModifiedBy
                    LastModifiedDate = DateTime.Now // Set the current date and time
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 14,
                    Name = "Sick",
                    CreatedBy = "System", // Set a default value for CreatedBy
                    DateCreated = DateTime.Now, // Set the current date and time
                    LastModifiedBy = "System", // Set a default value for LastModifiedBy
                    LastModifiedDate = DateTime.Now // Set the current date and time
                }
            );
        }
    }
}
