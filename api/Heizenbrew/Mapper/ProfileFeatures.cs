using AutoMapper;
using Core.Models;
using Infrustructure.Dto;
using Infrustructure.Dto.UserProfile;

namespace megamart_api.Mapper
{
    public class ProfileFeatures : Profile
    {
        public ProfileFeatures()
        {
            CreateMap<Brewer, BrewerProfileDto>()
                .ForCtorParam(nameof(BrewerProfileDto.FullName),
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<UpdateBrewerProfileDto, Brewer>();        
        }
    }
}
