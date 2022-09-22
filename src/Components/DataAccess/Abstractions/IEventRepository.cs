﻿using Core.OrchestratorModels;

namespace DataAccess.Abstractions
{
    public interface IEventRepository
    {
        EventEntity GetEvent(Guid id);
        EventEntity GetNextEvent(long flowId);
        void AddEvent(EventEntity entity);
        void Update(EventEntity entity);
        void AddOrUpdateEventEntity(EventEntity eventEntity);
        IEnumerable<EventEntity> GetEventsByTenant(int tenantId);
        IEnumerable<EventEntity> GetEventFlow(long flowId);

    }
}
