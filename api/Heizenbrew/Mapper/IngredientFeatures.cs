using AutoMapper;
using Core.Models.Equipment;
using Core.Models.Ingredient;
using Infrustructure.Dto.Equipment;
using Infrustructure.Dto.Ingredient;
using static System.Net.WebRequestMethods;

namespace heisenbrew_api.Mapper
{
    public class IngredientFeatures : Profile
    {
        public IngredientFeatures()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<CreateIngredientDto, Ingredient>();
            CreateMap<UpdateIngredientDto, Ingredient>();

            CreateMap<BrewerIngredient, BrewerIngredientDto>()
                .ForCtorParam(nameof(BrewerIngredientDto.Name), otp => otp.MapFrom(src => src.Ingredient.Name))
                .ForCtorParam(nameof(BrewerIngredientDto.ImgUrl), otp => otp.MapFrom(src => src.Ingredient.ImgUrl));
;
        }
    }
}
