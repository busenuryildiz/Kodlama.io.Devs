using Application.Features.OperationClaims.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Application.Features.OperationClaims.Models;
using Application.Features.OperaionClaims.Commands.CreateOperationClaims;
using Application.Features.OperaionClaims.Commands.DeleteOperationClaim;
using Application.Features.OperaionClaims.Commands.UpdateOperationClaim;

namespace Application.Features.OperationClaims.Profiles
{
    public class OperationClaimMappingProfiles : Profile
    {
        public OperationClaimMappingProfiles()
        {
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            //CreateMap<OperationClaim, OperationClaimGetByIdDto>().ReverseMap();

        }
    }
}
