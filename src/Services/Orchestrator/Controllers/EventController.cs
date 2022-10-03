using Core.OrchestratorModels;
using Dapr.Client;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using StateMachine.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orchestrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventRepository _eventRepository;
        private readonly FlowRepository _flowRepository;
        private readonly WorkFlowProcessor _workflowProcessor;
        private readonly ILogger<EventController> _logger;

        public EventController(EventRepository eventRepository, FlowRepository flowRepository, WorkFlowProcessor workFlowProcessor, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _flowRepository = flowRepository;
            _workflowProcessor = workFlowProcessor;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public async Task<EventEntity> ExecuteEvent(Guid id)
        {
            var entity = Get(id);
            await _workflowProcessor.ProcessEvent(entity);
            return entity;
        }

        [HttpPost("[action]")]
        public async Task<EventEntity> ExecuteFlow(long flowId)
        {
            var entity = await _workflowProcessor.ProcessFlow(flowId);
            return entity;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> GenerateReceiveEvents(long tenantId, EventType eventType) 
        {
            var fileList = await GetFileList(tenantId, eventType);
            if (fileList.Count == 0)
                return new ObjectResult("No files to download!");
            var eventCount = 0;
            var result = new List<string>();
            foreach (var fileName in fileList)
            {
                var entity = _eventRepository.AddOrGetEventFromFileName(tenantId, fileName, eventType);
                if (entity == null)
                    continue;
                eventCount++;
                result.Add(entity.Id.ToString());
            }
            result.Add(eventCount + " events in event store...");
            return new ObjectResult(result);
        }

        private async Task<List<string>> GetFileList(long tenantId, EventType eventType)
        {
            var source = new CancellationTokenSource();
            var cancellationToken = source.Token;
            var documentType = ProcessHelper.GetDocumentType(eventType);
            using var client = new DaprClientBuilder().Build();
            var request = client.CreateInvokeMethodRequest(HttpMethod.Get, "ingestion", "receivefile/getfilelist?tenantId=" + tenantId + "&documentType=" + documentType);
            var result = new List<string>();
            try
            {
                result = await client.InvokeMethodAsync<List<string>>(request, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
            return result;
        }

        // GET: api/<EventController>
        [HttpGet("[action]")]
        public IEnumerable<EventEntity> GetAll()
        {
            return _eventRepository.GetList();
        }

        [HttpGet("[action]")]
        public IEnumerable<Flow> GetActiveFlows()
        {
            return _flowRepository.GetActiveFlows().ToList();
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public EventEntity Get(Guid id)
        {
            return _eventRepository.Get(id);
        }

        // POST api/<EventController>
        [HttpPost("[action]")]
        public void Add([FromBody] EventEntity entity)
        {
            _eventRepository.Add(entity);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _eventRepository.Delete(id);
        }
    }
}
