using Core;
using Infrustructure.Dto.Recipe;
using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RecipeManagement
{
    public interface IRecipeService
    {
        public Task<Result<string, Error>> CreateRecipeAsync(CreateRecipeDto createRecipeDto);
        public Task<Result<string, Error>> UpdateRecipeAsync(CreateRecipeDto createRecipeDto);
        public Task<Result<string, Error>> DeleteRecipeAsync(CreateRecipeDto createRecipeDto);
        public Task<Result<string, Error>> VoteRecipeAsync(Guid recipeId, string voteStatus);
    }
}
