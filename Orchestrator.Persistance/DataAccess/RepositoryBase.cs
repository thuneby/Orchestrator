using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Orchestrator.Core.Models;
using Orchestrator.Persistance.Common;
using Orchestrator.Persistance.Models;

namespace Orchestrator.Persistance.DataAccess
{
    public class RepositoryBase<T1, T2> : IRepository<T1, T2> 
        where T1 : Entity<T2>
        where T2 : GuidModelBase
    {
        private readonly OrchestratorContext _context;
        private readonly ILogger<RepositoryBase<T1, T2>> _logger;

        public RepositoryBase(OrchestratorContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<RepositoryBase<T1, T2>>();
        }

        public IEnumerable<T1> GetAll(int take = 1000, int skip = 0)
        {
            var entities = Query(true).Skip(skip).Take(take).ToList();
            return entities;
        }

        public T1 Get(T2 id)
        {
            if (id == null)
                return null;
            var result = _context.Set<T1>().FirstOrDefault(x => x.Id == id);
            return result;
        }

        public void Add(T1 entity)
        {
            if (entity == null)
                return;
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T2 id)
        {
            var entity = _context.Set<T1>().FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                _logger.LogWarning("Delete Entity ({ID}) not found", id);
                return;
            }
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T1 entity)
        {
            var existing = Get(entity.Id);
            if (existing == null)
                return;
            _context.Update(entity);
            _context.SaveChanges();
        }

        private IQueryable<T1> Query(bool eager = false)
        {
            var query = _context.Set<T1>().AsQueryable();
            return !eager ? query : _context.Model.FindEntityType(typeof(T1)).GetNavigations().Aggregate(query, (current, property) => current.Include(property.Name));
        }
    }
}
