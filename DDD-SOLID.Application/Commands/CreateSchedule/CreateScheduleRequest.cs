using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Commands.CreateSchedule
{
    public class CreateScheduleRequest :IRequest<Guid>
    {
        public Guid AgentId { get; set; }

        public Guid CustomerId { get; set; }
        public Guid TimeSlotId { get; set; }
        public string Status { get; set; } = "Avaiable";
    }
}
