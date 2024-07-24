using HRLeaveManagementApplication.Persistence.Contracts;
using HRLeaveManagementDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRLeaveManagementPersistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
