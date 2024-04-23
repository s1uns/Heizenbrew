using AutoMapper;
using Core.Models.Equipment;
using Infrustructure.Dto.Equipment;

namespace heisenbrew_api.Mapper
{
    public class EquipmentFeatures : Profile
    {
        public EquipmentFeatures()
        {
            CreateMap<BrewingEquipment, BrewingEquipmentFullInfoDto>();
            CreateMap<BrewingEquipment, BrewerBrewingEquipmentShortInfoDto>();
            CreateMap<CreateBrewingEquipmentDto, BrewingEquipment>();
            CreateMap<UpdateBrewingEquipmentDto, BrewingEquipment>();

            CreateMap<BrewerBrewingEquipment, BrewerBrewingEquipmentShortInfoDto>()
                .ForCtorParam(nameof(BrewerBrewingEquipmentShortInfoDto.Name), otp => otp.MapFrom(src => src.BrewingEquipment.Name))
                .ForCtorParam(nameof(BrewerBrewingEquipmentShortInfoDto.ImgUrl), otp => otp.MapFrom(src => src.BrewingEquipment.ImgUrl));

            CreateMap<BrewerBrewingEquipment, BrewerBrewingEquipmentFullInfoDto>()
                .ForCtorParam(nameof(BrewerBrewingEquipmentShortInfoDto.Name), otp => otp.MapFrom(src => src.BrewingEquipment.Name))
                .ForCtorParam(nameof(BrewerBrewingEquipmentShortInfoDto.ImgUrl), otp => otp.MapFrom(src => src.BrewingEquipment.ImgUrl));
        }
    }
}
