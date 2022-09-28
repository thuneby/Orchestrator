using Core.CoreModels;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class OutputFileRepository: GuidRepositoryBase<OutputFile>
    {
        private readonly BlobContext _blobContext;
        public OutputFileRepository(BlobContext context, ILogger<GuidRepositoryBase<OutputFile>> logger) : base(context, logger)
        {
            _blobContext = context;
        }

        public async Task<List<OutputFile>> GetOutputFiles(long flowId)
        {
            return await _blobContext.OutputFiles.Where(x => x.FlowId == flowId).ToListAsync();
        }
    }
}
