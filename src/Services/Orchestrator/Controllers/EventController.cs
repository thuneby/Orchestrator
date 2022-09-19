using Configuration.Models;
using Core.Models;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StateMachine.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orchestrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventRepository _repository;
        private readonly WorkFlowProcessor _workflowProcessor;
        private readonly ILogger<EventController> _logger;
        private IOptions<ServiceConfig> _serviceOptions;

        public EventController(EventRepository repository, WorkFlowProcessor workFlowProcessor, IOptions<ServiceConfig> options, ILogger<EventController> logger)
        {
            _repository = repository;
            _workflowProcessor = workFlowProcessor;
            _serviceOptions = options;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public async Task<EventEntity> ExecuteEvent(Guid id)
        {
            var entity = Get(id);
            await _workflowProcessor.ProcessEvent(entity);
            return entity;
        }


        // GET: api/<EventController>
        [HttpGet("[action]")]
        public IEnumerable<EventEntity> GetAll()
        {
            return _repository.GetAll();
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public EventEntity Get(Guid id)
        {
            return _repository.Get(id);
        }

        // POST api/<EventController>
        [HttpPost("[action]")]
        public void Add([FromBody] EventEntity entity)
        {
            _repository.Add(entity);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}
