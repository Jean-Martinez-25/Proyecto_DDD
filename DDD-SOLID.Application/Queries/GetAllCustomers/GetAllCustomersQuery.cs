using DDD_SOLID.Application.Queries.GetCustomersById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDto>>
    {

    }
}
