Feature: Changed estimate notification
	In order to know when estimates of a Bug are changed
	As a Manager
	I want to recieve notification by email
	As a System
	I want to know that email was sent

@notification @mail
Scenario: Send mail notification to Manager
	Given I report a new bug 'cannot click on button' without an estimate
	  And I assign a Developer
	  And I assign myself as a Manager and my mail address is 'manager@company'
	 When Developer changes estimate
	 Then Email is sent to 'manager@company'

@notification @event
Scenario: Add event when notification is sent
	Given I report a new bug 'cannot click on button' without an estimate
	  And I assign a Developer
	  And I assign myself as a Manager and my mail address is 'manager@company'
     When Developer changes estimate
     Then Bug should have 1 event of type 'NotifiedManagerAboutChangedEstimateEvent'
