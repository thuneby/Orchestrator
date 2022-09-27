using Core.CoreModels;

namespace DataAccess.Abstractions
{
    public interface IGuidRepository<T>
    {
        Tenant Tenant { set; }
        IEnumerable<T> GetList(int take, int skip);
        IQueryable<T> GetQueryList();
        T Get(Guid id);
        void Add(T entity);
        void Delete(Guid id);
        void Update(T entity);
    }
}
