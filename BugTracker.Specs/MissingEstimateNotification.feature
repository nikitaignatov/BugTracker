Feature: Missing estimate notification
	As a Manager
	I want to notify developers about bugs that are not estimated

Scenario: Send mail notification to Developer
	Given I report a new bug 'cannot click on button' without an estimate
	 When I assign a Developer with mail address 'dev@company'
	 Then 1 mail is sent to 'dev@company'

Scenario: Add event when mail is sent to Developer
	Given I report a new bug 'cannot click on button' without an estimate
	 When I assign a Developer with mail address 'dev@company'
	 Then Bug should have 1 event of type 'NotifiedDevelopersAboutMissingEstimateEvent'

Scenario: Add event when notification is failed to be sent to Developer
	Given I report a new bug 'cannot click on button' without an estimate
	 When I assign a Developer with mail address '_'
	 Then Bug should have 1 event of type 'FailedToNotifyResourceEvent'
