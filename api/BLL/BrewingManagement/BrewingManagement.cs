using AutoMapper;
using BLL.BrewingManagement;
using Core;
using DAL;
using Infrustructure.Dto.Brewing;
using Infrustructure.ErrorHandling.Errors.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BrewingManagement
{
    public class BrewingManagement : IBrewingManagement
    {
        private readonly ILogger<BrewingManagement> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public BrewingManagement(ILogger<BrewingManagement> logger, IMapper mapper, ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public Task<Result<string, Error>> AbortBrewingAsync(Guid equipmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string, Error>> GetBrewingStatusAsync(Guid equipmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<BrewingDto>, Error>> GetBrewingBrewingsAsync(Guid equipmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string, Error>> StartBrewingAsync(Guid recipeId, Guid equipmentId)
        {
            throw new NotImplementedException();
        }
    }
}
