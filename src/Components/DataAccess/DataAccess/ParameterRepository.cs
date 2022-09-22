using Core.Models;
using DataAccess.Abstractions;
using DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class ParameterRepository : GuidRepositoryBase<ParameterEntity>, IGuidRepository<ParameterEntity>
    {
        public ParameterRepository(OrchestratorContext context, ILogger<ParameterRepository> logger) : base(context, logger)
        {
        }
    }
}
