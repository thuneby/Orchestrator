using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{
    public class EventController : Controller
    {
        private readonly EventRepository _repository;
        private readonly ILogger<EventController> _logger;

        public EventController(EventRepository eventRepository, ILogger<EventController> logger)
        {
            _repository = eventRepository;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            var result = _repository.GetQueryList().OrderBy(x => x.FlowId).ThenBy(x => x.ProcessState);
            return View(result);
        }
    }
}
