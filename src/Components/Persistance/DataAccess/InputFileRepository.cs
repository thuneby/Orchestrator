using Core.Models;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class InputFileRepository: GuidRepositoryBase<InputFile>
    {
        private readonly BlobContext _blobContext;
        public InputFileRepository(BlobContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
            _blobContext = context;
        }

        public async Task<InputFile> Get(string fileName)
        {
            return await _blobContext.InputFiles.FirstOrDefaultAsync(x => x.FileName == fileName);
        }
    }
}
