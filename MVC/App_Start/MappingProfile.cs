using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVC.Dtos;
using MVC.Models;

namespace MVC
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            // Domain to Dto
            CreateMap<Cliente, ClienteDto>();

            // Dto to Domain
            CreateMap<ClienteDto, Cliente>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}