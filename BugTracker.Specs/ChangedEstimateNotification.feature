Feature: Changed estimate notification
	In order to know when estimates are changed
	As a Manager
	I want to recieve notification

@notification @mail
Scenario: Send mail notification to Manager
	Given I have a bug 'cannot click on button'
	And It is missing an estimate
	And It has Developer in resources
	And It has Me as Manager in resources
	When Developer changes estimate
	Then I should recieve 1 email

@notification @event
Scenario: Add event when notification is sent
	Given I have a bug 'cannot click on button'
	And It is missing an estimate
	And It has Developer in resources
	And It has Me as Manager in resources
	When Developer changes estimate
	Then Bug should have 1 event of type 'NotifiedManagerAboutChangedEstimateEvent'
