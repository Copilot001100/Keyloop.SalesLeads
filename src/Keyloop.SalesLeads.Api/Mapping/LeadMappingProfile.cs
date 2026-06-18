using AutoMapper;
using Keyloop.SalesLeads.Api.Contracts;
using Keyloop.SalesLeads.Api.Models;

namespace Keyloop.SalesLeads.Api.Mapping;

public class LeadMappingProfile : Profile
{
    public LeadMappingProfile()
    {
        CreateMap<Lead, LeadResponse>()
            .ForMember(
                dest => dest.Activities,
                opt => opt.MapFrom(src => src.Activities.OrderByDescending(a => a.Timestamp)));

        CreateMap<LeadActivity, LeadActivityResponse>();

        CreateMap<CreateLeadRequest, Lead>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.Activities, opt => opt.Ignore());

        CreateMap<CreateActivityRequest, LeadActivity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.LeadId, opt => opt.Ignore())
            .ForMember(dest => dest.Lead, opt => opt.Ignore())
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(
                dest => dest.PerformedBy,
                opt => opt.MapFrom(src => src.PerformedBy ?? ActivityPerformedBy.SalesRep));
    }
}
