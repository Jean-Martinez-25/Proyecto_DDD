using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Domain.Interfaces
{
    public interface IAgentRepository
    {
        Task<bool> ExistsAsync(Guid agentId);
    }
}
