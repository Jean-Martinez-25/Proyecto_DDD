using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Commands.CreateCall
{
    public class CreateCallRequest
    {
        public Guid CustomerId { get; set; } = Guid.Empty;
        public string Subject {  get; set; } = string.Empty;
        public string Notes {  get; set; } = string.Empty;
    }
}
