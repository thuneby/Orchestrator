using Core.Models;
using Microsoft.Extensions.Logging;
using Persistance.Common;
using Persistance.Models;

namespace Persistance.DataAccess
{
    public class FlowRepository: ModelRepositoryBase<Flow>, IRepository<Flow, long>
    {
        public FlowRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
