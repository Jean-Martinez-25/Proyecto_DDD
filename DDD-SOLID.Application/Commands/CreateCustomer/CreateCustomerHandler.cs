using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD_SOLID.Domain.Entities;
using DDD_SOLID.Domain.Interfaces;
using MediatR;

namespace DDD_SOLID.Application.Commands.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, Guid>
    {
        private readonly ICustomerRepository _repository;
        public CreateCustomerHandler(ICustomerRepository repository) { 
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.FullName, request.Email, request.PhoneNumber);
            await _repository.AddAsync(customer);
            return customer.Id;
        }
    }
}
