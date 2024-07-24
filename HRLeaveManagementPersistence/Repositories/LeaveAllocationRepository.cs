using HRLeaveManagementApplication.Contracts.Persistence;
using HRLeaveManagementDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementPersistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContect;
        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContect.leaveAllocations
                 .Include(x => x.LeaveType)
                 .FirstOrDefaultAsync(x => x.Id == id);

            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocation = await _dbContect.leaveAllocations
                .Include(x=> x.LeaveType)
                .ToListAsync();

            return leaveAllocation;
        }
    }
}
