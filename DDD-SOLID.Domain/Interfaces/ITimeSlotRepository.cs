using DDD_SOLID.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Domain.Interfaces
{
    public interface ITimeSlotRepository
    {
        Task<TimeSlot?> GetByIdAsync(Guid timeSlotId);
        Task MarkAsUnuvailebleAsync(Guid timeSlotId);
    }
}
