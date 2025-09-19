using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Commands.CreateCall
{
    public class CreateCallValidator: AbstractValidator<CreateCallRequest>
    {
        public CreateCallValidator() { 
        
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Subject).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Notes).NotEmpty().MaximumLength(500);
        }
    }
}
