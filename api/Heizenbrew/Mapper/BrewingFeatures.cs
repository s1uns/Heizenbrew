using AutoMapper;
using Core.Models;
using Infrustructure.Dto.Brewing;

namespace heisenbrew_api.Mapper
{
    public class BrewingFeatures : Profile
    {
        public BrewingFeatures()
        {
/*            CreateMap<Brewing, BrewingFullInfoDto>()
                .ForCtorParam(nameof(BrewingFullInfoDto.EquipmentTitle), otp => otp.MapFrom(src => src.BrewerBrewingEquipment.BrewingEquipment.Name))
                .ForCtorParam(nameof(BrewingFullInfoDto.RecipeTitle), otp => otp.MapFrom(src => src.Recipe.Title))
                .ForCtorParam(nameof(BrewingFullInfoDto.LastUpdateDate), otp => otp.MapFrom(src => src.BrewingLogs.Select(b => b.LogTime).LastOrDefault()));*/
            CreateMap<BrewingLog, BrewingLogDto>();
        }
    }
}
