using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Persistance.DataAccess;

namespace OrchestratorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly TenantRepository _repository;
        private readonly ILogger<EventController> _logger;

        public TenantController(TenantRepository repository, ILogger<EventController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        // GET: api/<EventController>
        [HttpGet("GetAll")]
        public IEnumerable<Tenant> GetAll()
        {
            return _repository.GetAll();
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public Tenant Get(long id)
        {
            return _repository.Get(id);
        }

        // POST api/<EventController>
        [HttpPost]
        public void Add([FromBody] Tenant entity)
        {
            _repository.Add(entity);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
