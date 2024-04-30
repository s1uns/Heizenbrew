using AutoMapper;
using Core.Models;
using Infrustructure.Dto.Recipe;

namespace heisenbrew_api.Mapper
{
    public class RecipeFeatures : Profile
    {
        public RecipeFeatures()
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<CreateRecipeDto, Recipe>();
            CreateMap<UpdateRecipeDto, Recipe>();
        }
    }
}
