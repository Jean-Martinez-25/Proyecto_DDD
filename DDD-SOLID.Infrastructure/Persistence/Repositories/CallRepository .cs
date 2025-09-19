using DDD_SOLID.Domain.Entities;
using DDD_SOLID.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Infrastructure.Persistence.Repositories
{
    public class CallRepository: ICallRepository
    {
        private readonly AppDbContext _context;

        public CallRepository(AppDbContext appDbContext) {
            _context = appDbContext;
        }

        public async Task<Guid> CreateAsync(Call call)
        {
            _context.Calls.Add(call);
            await _context.SaveChangesAsync();
            return call.Id;
        }
        public async Task<List<Call>> GetByCustomerIdAsync(Guid customerId)
        {
            return await _context.Calls
                .Where(c => c.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<Call?> GetCallByIdAsync(Guid Id)
        {
            return await _context.Calls
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<IEnumerable<Call>> GetAllAsync()
        {
            return await _context.Calls
                .Include(c => c.Customer)
                .ToListAsync();
        }
    }
}
