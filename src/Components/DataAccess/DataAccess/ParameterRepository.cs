﻿using Core.OrchestratorModels;
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

        public IEnumerable<ParameterEntity> GetParameters(long tenantId)
        {
            return GetQueryList().Where(x => x.TenantÍd == tenantId).ToList();
        }
    }
}
