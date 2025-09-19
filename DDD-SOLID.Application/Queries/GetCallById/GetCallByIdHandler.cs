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

namespace DDD_SOLID.Application.Queries.GetCallById
{
    public class GetCallByIdHandler : IRequestHandler<GetCallByIdQuery, CallDto?>
    {
        private readonly ICallRepository _callRepository;
        private readonly IMapper _mapper;
        public GetCallByIdHandler(ICallRepository callRepository, IMapper  mapper) { 
            _callRepository = callRepository;
            _mapper = mapper;
        }

        public async Task<CallDto?> Handle(GetCallByIdQuery request, CancellationToken cancellationToken)
        {
            var calls = await _callRepository.GetCallByIdAsync(request.Id);
            var dto  = _mapper.Map<CallDto>(calls);
            return dto;
        }
    }
}
