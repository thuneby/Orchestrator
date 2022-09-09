﻿using Core.Models;

namespace Persistance.Common
{
    public interface IGuidRepository<T>
    {
        Tenant Tenant { set; }
        IEnumerable<T> GetAll(int take, int skip);
        T Get(Guid id);
        void Add(T entity);
        void Delete(Guid id);
        void Update(T entity);
    }
}