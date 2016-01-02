Feature: Changed estimate notification
	In order to know when estimates of a Bug are changed
	As a Manager
	I want to recieve notification by email
	As a System
	I want to know that email was sent
	I want to know if an email could not be sent

@notification
Scenario: Change estimate
	Given I report a new bug 'cannot click on button' without an estimate
	  And I assign a Developer with mail address 'dev@company'
	  And I assign myself as a Manager and my mail address is 'manager@company'
	 When Developer changes estimate to 2 hours
	 Then 1 mail is sent to 'manager@company'
	  And Bug should have 1 event of type 'NotifiedManagerAboutChangedEstimateEvent'

@notification
Scenario: Change estimate multiple times
	Given I report a new bug 'cannot click on button' without an estimate
	  And I assign a Developer with mail address 'dev@company'
	  And I assign myself as a Manager and my mail address is 'manager@company'
	 When Developer changes estimate to 2 hours
	 When Developer changes estimate to 4 hours
	 When Developer changes estimate to 6 hours
	 Then 3 mails is sent to 'manager@company'
	  And Bug should have 3 event of type 'NotifiedManagerAboutChangedEstimateEvent'

@notification @event @failure
Scenario: Failure when sending mail
	Given I report a new bug 'cannot click on button' without an estimate
	  And I assign a Developer with mail address 'dev@company'
	  And I assign myself as a Manager and my mail address is '&'
	 When Developer changes estimate to 2 hours
	 Then Bug should have 1 event of type 'FailedToNotifyResourceEvent'
