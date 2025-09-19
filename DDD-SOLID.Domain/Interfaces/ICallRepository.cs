using DDD_SOLID.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Domain.Interfaces
{
    public interface ICallRepository
    {
        Task<Guid> CreateAsync(Call call);
        Task<List<Call>> GetByCustomerIdAsync(Guid customerId);
        Task<Call?> GetCallByIdAsync(Guid customerId);
        Task<IEnumerable<Call>> GetAllAsync();
    }
}
