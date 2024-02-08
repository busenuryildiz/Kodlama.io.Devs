using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SoftwareTechs.Commands.CreateSoftwareTech;
using Application.Features.SoftwareTechs.Dtos;
using Core.Persistence.Paging;
using Domain.Entities;
using Application.Features.SoftwareTechs.Models;
using Application.Features.SoftwareTechs.Commands.UpdateSoftwareTech;
using Application.Features.SoftwareTechs.Commands.DeleteSoftwareTech;

namespace Application.Features.SoftwareTechs.Profiles
{
    public class SoftwareTechMappingProfiles : Profile
    {
        public SoftwareTechMappingProfiles()
        {
            CreateMap<SoftwareTech, CreatedSoftwareTechDto>().ReverseMap();
            CreateMap<SoftwareTech, UpdatedSoftwareTechDto>().ReverseMap();
            CreateMap<SoftwareTech, DeletedSoftwareTechDto>().ReverseMap();
            CreateMap<SoftwareTech, CreateSoftwareTechCommand>().ReverseMap();
            CreateMap<SoftwareTech, UpdateSoftwareTechCommand>().ReverseMap();
            CreateMap<SoftwareTech, DeleteSoftwareTechCommand>().ReverseMap();
            CreateMap<IPaginate<SoftwareTech>, SoftwareTechListModel>().ReverseMap();
            CreateMap<SoftwareTech, SoftwareTechListDto>()
                .ForMember(a=>a.ProgrammingLanguageName, b=>b.MapFrom(c=>c.ProgrammingLanguage.Name))
               .ReverseMap();
            CreateMap<SoftwareTech, SoftwareTechGetByIdDto>().ReverseMap();

        }
    }
}
