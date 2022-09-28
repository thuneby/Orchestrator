using Core.CoreModels;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Orchestrator.Controllers
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


        [HttpGet("[action]")]
        public IEnumerable<Tenant> GetAllTenants()
        {
            return _repository.GetAll();
        }

        [HttpGet("[action]")]
        public Tenant Get(long id)
        {
            return _repository.Get(id);
        }

        [HttpPost("[action]")]
        public void Add([FromBody] Tenant entity)
        {
            _repository.Add(entity);
        }

        [HttpPost("[action]")]
        public void Update([FromBody] Tenant entity)
        {
            _repository.Update(entity);
        }


        [HttpDelete("[action]")]
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
