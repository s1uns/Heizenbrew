using AutoMapper;
using Core.Models;
using Infrustructure.Dto.Recipe;

namespace heisenbrew_api.Mapper
{
    public class RecipeFeatures : Profile
    {
        public RecipeFeatures()
        {
            CreateMap<Recipe, RecipeDto>()
                .ForMember(rD => rD.Ingredients, opt => opt.MapFrom(r => r.Ingredients));

            CreateMap<CreateRecipeDto, Recipe>();
            CreateMap<UpdateRecipeDto, Recipe>();
        }
    }
}
