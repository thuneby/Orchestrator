using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CoreModels;
using DocumentAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccess.DocumentAccessLayer
{
    public abstract class DocumentRepositoryBase<T>
        where T : DocumentModelBase
    {
        private readonly DocumentContext _context;

        protected DocumentRepositoryBase(DocumentContext context)
        {
            _context = context;
        }

        public string User { get; set; }
        public Tenant Tenant { get; set; }


        public void Add(T entity, bool saveChanges = true)
        {
            if (entity == null)
            {
                //_logger.LogWarning(LoggingEvents.AddEntityNull, GetLoggingInfo() + "Add null Entity");
                return;
            }
            _context.Set<T>().Add(entity);
            if (saveChanges)
                _context.SaveChanges();
        }

        public async Task AddRange(List<T> entities)
        {
            if (!entities.Any() || entities.Any(x => x == null))
                return;
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public long Count()
        {
            return _context.Set<T>().Count();
            //return !Tenant.IsDefaultTenant ? _context.Set<T>().Count(x => x.TenantId == Tenant.Id) : _context.Set<T>().Count();
        }

        public void Delete(string id)
        {
            var entity = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                //_logger.LogWarning(LoggingEvents.DeleteEntityNotFound, GetLoggingInfo() + "Delete Entity ({ID}) not found", id);
                return;
            }
            _context.SaveChanges();
        }

        public T Get(string id)
        {
            return Query().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return TenantFilter(Query(true));
        }

        private IQueryable<T> Query(bool eager = false)
        {
            var query = _context.Set<T>().AsQueryable();
            return !eager ? query : _context.Model.FindEntityType(typeof(T)).GetNavigations().Aggregate(query, (current, property) => current.Include(property.Name));
        }

        protected IQueryable<T> TenantFilter(IQueryable<T> query)
        {
            return !Tenant.IsDefaultTenant ? query.Where(x => x.TenantId == Tenant.Id) : query;
        }

        public void Update(T entity, bool auditLoggingOn)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}

