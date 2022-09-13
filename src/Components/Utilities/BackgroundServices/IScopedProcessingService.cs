﻿using System.Threading;
using System.Threading.Tasks;

namespace Utilities.BackgroundServices
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}
