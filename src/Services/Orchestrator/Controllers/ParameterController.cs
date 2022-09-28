using Core.OrchestratorModels;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utilities.Ftp;

namespace Orchestrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly ParameterRepository _repository;
        private readonly ILogger<EventController> _logger;

        public ParameterController(ParameterRepository repository, ILogger<EventController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("[action]")]
        public IEnumerable<ParameterEntity> GetAll()
        {
            return _repository.GetList();
        }

        [HttpGet("[action]")]
        public ParameterEntity Get(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpPost("[action]")]
        public void Add([FromBody] ParameterEntity entity)
        {
            _repository.Add(entity);
        }

        [HttpPost("[action]")]
        public void Update([FromBody] ParameterEntity entity)
        {
            _repository.Update(entity);
        }

        [HttpPost("[action]")]
        public void UpdateFtpSettings(Guid id, [FromBody] FtpSettings settings)
        {
            var entity = _repository.Get(id);
            entity.Value = JsonConvert.SerializeObject(settings);
            _repository.Update(entity);
        }


        [HttpDelete("[action]")]
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}
