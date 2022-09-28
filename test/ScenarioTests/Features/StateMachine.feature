Feature: StateMachine

Testing the State Machine

@tag1
Scenario Outline: GetNextState
	When the event with EventType <Event_Type> and ProcessState <Process_State>
	Then the ProcessState of the next event is <Next_Process_State>

	Examples: 
	| Event_Type   | Process_State     | Next_Process_State |
	| HandleOsInfo | Receive           | Parse              |
	| HandleOsInfo | Parse             | Convert            |
	| HandleOsInfo | Convert           | Validate           |
	| HandleOsInfo | Validate          | Pay                |
	| HandleOsInfo | Pay               | GenerateReceipt    |
	| HandleOsInfo | GenerateReceipt   | TransferResult     |
	| HandleOsInfo | TransferResult    | WorkFlowCompleted  |
	| HandleOsInfo | WorkFlowCompleted | WorkFlowCompleted  |
	| GenerateIs   | Consolidate       | Pay                |
	| GenerateIs   | Pay               | TransferResult     |
	| GenerateIs   | TransferResult    | WorkFlowCompleted  |
	| GenerateIs   | WorkFlowCompleted | WorkFlowCompleted  |

