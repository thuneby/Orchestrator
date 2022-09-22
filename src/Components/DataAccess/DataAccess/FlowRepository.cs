using Core.OrchestratorModels;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class FlowRepository : ModelRepositoryBase<Flow>
    {
        private readonly OrchestratorContext _context;
        private readonly ILogger<FlowRepository> _logger;

        public FlowRepository(OrchestratorContext context, ILogger<FlowRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public long GetNextFlowId(int tenantId, EventType eventType)
        {
            long result = 0;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Get row with table lock
                    var flow = _context.Flow
                        .FromSqlRaw(
                            "Select Top 1 * from Flow With (TABLOCKX) WHERE TenantId = {0} And State = 0  Order By Id",
                            tenantId).FirstOrDefault();
                    if (flow?.Id > 0)
                    {
                        result = flow.Id;
                        flow.State = FlowState.Active;
                        Update(flow);
                        transaction.Commit();
                    }
                }
                // end table lock
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    transaction.Rollback();
                }
            }
            return result;
        }

        public IQueryable<Flow> GetActiveFlows()
        {
            var flows = _context.Flow.Include(x => x.Events.OrderBy(e => e.ProcessState))
                .Where(x => x.Events.Any(e => e.State != EventState.Completed));
            return flows;
        }

    }
}
