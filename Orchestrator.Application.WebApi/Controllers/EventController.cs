using Microsoft.AspNetCore.Mvc;
using Orchestrator.Core.Models;
using Orchestrator.Persistance.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orchestrator.Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventRepository _repository;
        private readonly ILogger<EventController> _logger;

        public EventController(EventRepository repository, ILogger<EventController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        // GET: api/<EventController>
        [HttpGet("GetAll")]
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
        [HttpPost]
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
