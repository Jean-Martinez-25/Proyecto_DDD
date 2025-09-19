using DDD_SOLID.Domain.Entities;
using DDD_SOLID.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Commands.CreateCall
{
    public class CreateCallHandler : IRequestHandler<CreateCallCommand, Guid>
    {
        private readonly ICallRepository _callRepository;

        public CreateCallHandler(ICallRepository callRepository) { 
            _callRepository = callRepository;
        }

        public async Task<Guid> Handle(CreateCallCommand command, CancellationToken cancellationToken)
        {
            var call = new Call
            {
                Id = new Guid(),
                CustomerId  = command.Request.CustomerId,
                Notes = command.Request.Notes,
                Subject = command.Request.Subject,
                Timestamp = DateTime.UtcNow,
            };

            await _callRepository.CreateAsync(call);
            return call.Id;
        }
    }
}
