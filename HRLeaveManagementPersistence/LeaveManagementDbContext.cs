using HRLeaveManagementDomain;
using HRLeaveManagementDomain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagementPersistence
{
    public class LeaveManagementDbContext : DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                if (entry.State == EntityState.Added) 
                { 
                    entry.Entity.DateCreated = DateTime.Now;
                }
           
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<LeaveRequest> leaveRequests { get; set; }
        public DbSet<LeaveType> leaveTypes { get; set; }
        public DbSet<LeaveAllocation> leaveAllocations { get; set; }
    }
}
