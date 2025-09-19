using DDD_SOLID.Application.Queries.GetCustomersById;
using DDD_SOLID.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersHandler: IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomersHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllAsync();
            
            return customers.Select( c => new CustomerDto
            {
                Id = c.Id,
                FullName = c.FullName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
            }).ToList();

        }
    }
}
