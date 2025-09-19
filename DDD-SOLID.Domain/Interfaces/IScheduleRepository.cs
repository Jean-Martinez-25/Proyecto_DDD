using DDD_SOLID.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Domain.Interfaces
{
    public interface IScheduleRepository
    {
        Task<bool> ExistsForAgentInTimeRangeAsync(Guid agentId, DateTime startTime, DateTime endTime);
        Task<bool> ExistsForCustomerInTimeRangeAsync(Guid customerId, DateTime startTime, DateTime endTime);
        Task<Guid> CreateAsync(Schedule schedule);
    }
}
