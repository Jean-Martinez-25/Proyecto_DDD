using DDD_SOLID.Application.DTOs;
using DDD_SOLID.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Queries.GetAllCalls
{
    public class GetAllCallsQuery : IRequest<IEnumerable<CallDto>>
    {

    }
}
