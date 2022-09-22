using Core.OrchestratorModels;
using DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class SagaRepository : ModelRepositoryBase<Saga>
    {
        public SagaRepository(OrchestratorContext context, ILogger<SagaRepository> logger) : base(context, logger)
        {
        }
    }
}
