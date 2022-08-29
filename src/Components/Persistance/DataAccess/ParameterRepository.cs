using Core.Models;
using Microsoft.Extensions.Logging;
using Persistance.Common;
using Persistance.Models;

namespace Persistance.DataAccess
{
    public class ParameterRepository: GuidRepositoryBase<ParameterEntity>, IGuidRepository<ParameterEntity>
    {
        public ParameterRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
