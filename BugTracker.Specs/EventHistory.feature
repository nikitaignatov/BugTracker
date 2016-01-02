Feature: Event History
	For auditing purposes all events should be stored
	As User
	I want to view events that occured for a given bug

@mytag
Scenario: View event history
	Given I report a new bug 'cannot click on button' without an estimate
	  And I assign myself as a Manager and my mail address is 'manager@company'
	  And I assign a Developer with mail address 'dev@company'
	 When Developer changes estimate to 8 hours
	 When Developer changes estimate to 4 hours
	 When Developer changes estimate to 6 hours
	 Then Bug should have event of type
	 | Occurances | Event type                                  |
	 | 1          | BugCreatedEvent                             |
	 | 2          | AssignedResourceEvent                       |
	 | 3          | ChangedEstimateEvent                        |
	 | 1          | NotifiedDevelopersAboutMissingEstimateEvent |
	 | 3          | NotifiedManagerAboutChangedEstimateEvent    |