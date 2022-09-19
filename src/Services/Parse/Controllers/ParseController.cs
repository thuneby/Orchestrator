﻿using BlobAccess.DataAccessLayer.Helpers;
using Core.Models;
using DocumentAccess.DocumentAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Parse.BusinessLogic;

namespace Parse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParseController : ControllerBase
    {
        private readonly IDocumentRepository _repository; 
        private readonly IStorageHelper _storageHelper;
        private readonly ILoggerFactory _loggerFactory;

        public ParseController(IDocumentRepository repository, IStorageHelper storageHelper, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _storageHelper = storageHelper;
            _loggerFactory = loggerFactory;
        }

        [HttpPost("[action]")]
        public async Task<Guid> ParseFromGuid([FromQuery] Guid fileId, [FromQuery] DocumentType documentType, [FromQuery] long tenantId) 
        {
            var parser = ParserFactory.GetParser(documentType, _storageHelper, _repository, _loggerFactory);
            var result = await parser.Parse(fileId, tenantId);

            return result;

        }
    }
}
