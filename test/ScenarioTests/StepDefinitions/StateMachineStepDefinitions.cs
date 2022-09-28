using Core.OrchestratorModels;
using StateMachine.BusinessLogic;

namespace ScenarioTests.StepDefinitions
{
    [Binding]
    public class StateMachineStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private EventEntity? _eventEntity;
        public StateMachineStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        [When(@"the event with EventType (.*) and ProcessState (.*)")]
        public void WhenTheEventWithEventTypeHandleOsInfoAndProcessStateReceive(EventType eventType, ProcessState processState)
        {
            _eventEntity = new EventEntity()
            {
                EventType = eventType,
                ProcessState = processState
            };
        }

        [Then(@"the ProcessState of the next event is (.*)")]
        public void ThenTheProcessStateOfTheNextEventIsParse(ProcessState processState)
        {
            var result = StateMap.GetNextStep(_eventEntity);
            result.Should().Be(processState);
        }
    }
}
