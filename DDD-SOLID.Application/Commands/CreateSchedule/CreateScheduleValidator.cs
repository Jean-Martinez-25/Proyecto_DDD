using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Commands.CreateSchedule
{
    public class CreateScheduleValidator :AbstractValidator<CreateScheduleRequest>
    {
        public CreateScheduleValidator() {
            RuleFor(x => x.AgentId).NotEmpty().WithMessage("AgentId es requerido.");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId es requerido.");
            RuleFor(x => x.TimeSlotId).NotEmpty().WithMessage("TimeSlotId es requerido.");
            RuleFor(x => x.Status)
                .NotEmpty()
                .MaximumLength(50)
                .Must(s => new[] { "Available", "Booked", "Cancelled" }.Contains(s))
                .WithMessage("Status inválido. Usa: Available, Booked o Cancelled.");
        }
    }
}
