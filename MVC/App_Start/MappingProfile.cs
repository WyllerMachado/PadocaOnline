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
            CreateMap<Fornada, FornadaDto>();

            // Dto to Domain
            CreateMap<FornadaDto, Fornada>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}