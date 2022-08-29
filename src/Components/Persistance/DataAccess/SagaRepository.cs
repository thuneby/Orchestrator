using Core.Models;
using Microsoft.Extensions.Logging;
using Persistance.Models;

namespace Persistance.DataAccess
{
    public class SagaRepository: ModelRepositoryBase<Saga>
    {
        public SagaRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
