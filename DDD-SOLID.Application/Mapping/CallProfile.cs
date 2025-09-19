using AutoMapper;
using DDD_SOLID.Domain.Entities;
using DDD_SOLID.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Application.Mapping
{
    public class CallProfile : Profile
    {
        public CallProfile() { 
            CreateMap<Call, CallDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.FullName : ""));
        }
    }
}
