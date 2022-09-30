﻿using Configuration.Models;
using Core.CoreModels;
using Core.OrchestratorModels;
using DataAccess.DataAccess;
using Ingestion.Controllers;
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
        private readonly EventRepository _eventRepository;
        private readonly FlowRepository _flowRepository;
        private readonly WorkFlowProcessor _workflowProcessor;
        private readonly ReceiveFileController _receiveFileController;
        private readonly ILogger<EventController> _logger;
        private IOptions<ServiceConfig> _serviceOptions;

        public EventController(EventRepository eventRepository, FlowRepository flowRepository, WorkFlowProcessor workFlowProcessor, ReceiveFileController receiveFileController, 
            IOptions<ServiceConfig> options, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _flowRepository = flowRepository;
            _workflowProcessor = workFlowProcessor;
            _receiveFileController = receiveFileController;
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

        [HttpPost("[action]")]
        public async Task<EventEntity> ExecuteFlow(long flowId)
        {
            var entity = await _workflowProcessor.ProcessFlow(flowId);
            return entity;
        }

        [HttpPost("[action]")]
        public ActionResult GenerateReceiveEvents(long tenantId, EventType eventType) 
        {
            var fileList = _receiveFileController.GetFileList(tenantId, ProcessHelper.GetDocumentType(eventType));
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
