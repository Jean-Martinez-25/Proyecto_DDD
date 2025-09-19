using DDD_SOLID.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Commands.CreateSchedule
{
    public class CreateScheduleHandler : IRequestHandler<CreateScheduleRequest, Guid>
    {
        private readonly IAgentRepository _agenteRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public CreateScheduleHandler(IAgentRepository agenteRepository, ICustomerRepository customerRepository, ITimeSlotRepository timeSlotRepository, IScheduleRepository scheduleRepository)
        {
            _agenteRepository = agenteRepository;
            _customerRepository = customerRepository;
            _timeSlotRepository = timeSlotRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Guid> Handle(CreateScheduleRequest request, CancellationToken cancellationToken)
        {
            // 1) Existencias
            if (!await _agenteRepository.ExistsAsync(request.AgentId))
                throw new ArgumentException("El agente no existe.", nameof(request.AgentId));

            if(!await  _customerRepository.ExistsAsync(request.CustomerId))
                throw new ArgumentException("el cliente no existe.", nameof(request.CustomerId));

            var slot = await _timeSlotRepository.GetByIdAsync(request.TimeSlotId)
                ?? throw new ArgumentException("El time slot no existe", nameof(request.TimeSlotId));

            // 2) Reglas star < end
            if (slot.StartTime >= slot.EndTime)
                throw new ArgumentException("El rango de tiempo del slot es inválido.");

            // 3) Reglas de solapamiento
            return new Guid();

        }
    }
}
