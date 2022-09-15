using BlobAccess.DataAccessLayer.Helpers;
using Core.Models;
using DocumentAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Parse.BusinessLogic;

namespace Parse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParseController : ControllerBase
    {
        private readonly DocumentContext _context;
        private readonly IStorageHelper _storageHelper;
        private readonly ILoggerFactory _loggerFactory;

        public ParseController(DocumentContext context, IStorageHelper storageHelper, ILoggerFactory loggerFactory)
        {
            _context = context;
            _storageHelper = storageHelper;
            _loggerFactory = loggerFactory;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> ParseFromGuid([FromQuery] Guid fileId, [FromQuery] DocumentType documentType, [FromQuery] long tenantId) 
        {
            var parser = ParserFactory.GetParser(documentType, _storageHelper, _context, _loggerFactory);
            var result = await parser.Parse(fileId, tenantId);

            return result;

        }
    }
}
