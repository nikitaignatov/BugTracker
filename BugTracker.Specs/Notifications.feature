Feature: Notifications
	In order for everyone to be up to date with the changes to the bugs
	As a User
	I will recieve notitifications regarding changes that are relevant to me
	As a System
	I will send notifications and keep track of what has been sent

Scenario: Assign developer
	Given I report a new bug 'cannot click on button' without an estimate
	 When I assign a Developer with mail address 'dev@company'
	 Then 1 mail is sent to 'dev@company'
	  And Bug should have 1 event of type 'NotifiedDevelopersAboutMissingEstimateEvent'

Scenario: Fail when sending mail notification
	Given I report a new bug 'cannot click on button' without an estimate
	 When I assign a Developer with mail address '_'
	 Then Bug should have 1 event of type 'FailedToNotifyResourceEvent'

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