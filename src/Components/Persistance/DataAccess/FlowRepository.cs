﻿using Core.Models;
using DataAccess.Abstractions;
using DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class FlowRepository : ModelRepositoryBase<Flow>, IRepository<Flow, long>
    {
        private readonly OrchestratorContext _context;
        public FlowRepository(OrchestratorContext context, ILogger<FlowRepository> logger) : base(context, logger)
        {
            _context = context;
        }

    }
}
