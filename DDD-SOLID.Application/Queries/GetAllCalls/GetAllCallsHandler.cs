using AutoMapper;
using DDD_SOLID.Application.DTOs;
using DDD_SOLID.Domain.Entities;
using DDD_SOLID.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Queries.GetAllCalls
{
    public class GetAllCallsHandler : IRequestHandler<GetAllCallsQuery, IEnumerable<CallDto>>
    {
        private readonly ICallRepository _callRepository;
        private readonly IMapper _mapper;

        public GetAllCallsHandler(ICallRepository callRepository, IMapper mapper) { 
            _callRepository = callRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CallDto>> Handle(GetAllCallsQuery request, CancellationToken cancellationToken)
        {
            var calls  = await _callRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<CallDto>>(calls);
            return dtos;
        }
    }
}
