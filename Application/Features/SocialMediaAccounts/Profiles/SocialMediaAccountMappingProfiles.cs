using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SocialMediaAccounts.Commands.CreateSocialMediaAccount;
using Application.Features.SocialMediaAccounts.Dtos;
using Core.Persistence.Paging;
using Domain.Entities;
using Application.Features.SocialMediaAccounts.Models;
using Application.Features.SocialMediaAccounts.Commands.UpdateSocialMediaAccount;
using Application.Features.SocialMediaAccounts.Commands.DeleteSocialMediaAccount;

namespace Application.Features.SocialMediaAccounts.Profiles
{
    public class SocialMediaAccountMappingProfiles : Profile
    {
        public SocialMediaAccountMappingProfiles()
        {
            CreateMap<SocialMediaAccount, CreatedSocialMediaAccountDto>().ReverseMap();
            CreateMap<SocialMediaAccount, UpdatedSocialMediaAccountDto>().ReverseMap();
            CreateMap<SocialMediaAccount, DeletedSocialMediaAccountDto>().ReverseMap();
            CreateMap<SocialMediaAccount, CreateSocialMediaAccountCommand>().ReverseMap();
            CreateMap<SocialMediaAccount, UpdateSocialMediaAccountCommand>().ReverseMap();
            CreateMap<SocialMediaAccount, DeleteSocialMediaAccountCommand>().ReverseMap();
            CreateMap<IPaginate<SocialMediaAccount>, SocialMediaAccountListModel>().ReverseMap();
            CreateMap<SocialMediaAccount, SocialMediaAccountListDto>()
                .ForMember(g => g.UserName, opt => opt.MapFrom(g => $"{g.User.FirstName} {g.User.LastName}"))
                .ReverseMap();
            CreateMap<SocialMediaAccount, SocialMediaAccountGetByIdDto>().ReverseMap();

        }
    }
}
