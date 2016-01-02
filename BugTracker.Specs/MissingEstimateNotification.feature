Feature: Missing estimate notification
	As a Manager
	I want to notify developers about bugs that are not estimated

Scenario: Assign developer
	Given I report a new bug 'cannot click on button' without an estimate
	 When I assign a Developer with mail address 'dev@company'
	 Then 1 mail is sent to 'dev@company'
	  And Bug should have 1 event of type 'NotifiedDevelopersAboutMissingEstimateEvent'

Scenario: Fail when sending mail notification
	Given I report a new bug 'cannot click on button' without an estimate
	 When I assign a Developer with mail address '_'
	 Then Bug should have 1 event of type 'FailedToNotifyResourceEvent'
