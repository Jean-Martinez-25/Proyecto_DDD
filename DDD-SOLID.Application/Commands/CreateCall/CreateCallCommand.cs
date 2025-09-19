using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Commands.CreateCall
{
    public class CreateCallCommand : IRequest<Guid>
    {
        public CreateCallRequest Request { get; set; }
        public CreateCallCommand(CreateCallRequest request) { 
            Request = request;
        }
    }
}
