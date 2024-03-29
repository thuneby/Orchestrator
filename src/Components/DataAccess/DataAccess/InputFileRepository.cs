﻿using Core.CoreModels;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class InputFileRepository: GuidRepositoryBase<InputFile>
    {
        private readonly BlobContext _blobContext;
        public InputFileRepository(BlobContext context, ILogger<InputFileRepository> logger) : base(context, logger)
        {
            _blobContext = context;
        }

        public async Task<InputFile> Get(string fileName)
        {
            return await _blobContext.InputFiles.FirstOrDefaultAsync(x => x.FileName == fileName);
        }

        public async Task<string> GetInputFileName(Guid id)
        {
            return _blobContext.InputFiles.FirstOrDefault(x => x.Id == id)?.FileName ?? string.Empty;
        }
    }
}
