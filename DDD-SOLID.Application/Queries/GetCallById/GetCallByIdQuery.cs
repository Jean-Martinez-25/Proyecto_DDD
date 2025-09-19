using DDD_SOLID.Application.DTOs;
using DDD_SOLID.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Queries.GetCallById
{
    public class GetCallByIdQuery: IRequest<CallDto?>
    {
        public Guid Id { get; set; }
        public GetCallByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
