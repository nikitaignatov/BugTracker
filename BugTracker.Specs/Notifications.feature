@notification
Feature: Notifications
	In order for everyone to be up to date with the changes to the bugs
	As a User
	I will recieve notitifications regarding changes that are relevant to me
	As a System
	I will send notifications and keep track of what has been sent

Scenario Outline: Assign resources
	Given I report a new bug 'cannot click on button' without an estimate
	 When I assign a <resource type> with mail address '<mail address>'
	 Then <x> mails is sent to '<mail address>'
	  And Bug should have <y> events of type '<event>'

  Examples:
    | resource type | mail address | x | y | event                                       |
    | Developer     | dev@company  | 1 | 1 | NotifiedDevelopersAboutMissingEstimateEvent |
    | Developer     | _            | 0 | 1 | FailedToNotifyResourceEvent                 |
    | Manager       | dev@company  | 0 | 0 |                                             |
    | Manager       | &            | 0 | 0 |                                             |

Scenario: Assign developer
	Given I report a new bug 'cannot click on button' without an estimate
	 When I assign a Developer with mail address 'dev@company'
	 Then 1 mail is sent to 'dev@company'
	  And Bug should have 1 event of type 'NotifiedDevelopersAboutMissingEstimateEvent'

@failure
Scenario: Fail when sending mail notification
	Given I report a new bug 'cannot click on button' without an estimate
	 When I assign a Developer with mail address '_'
	 Then Bug should have 1 event of type 'FailedToNotifyResourceEvent'

Scenario: Change estimate
	Given I report a new bug 'cannot click on button' without an estimate
	  And I assign a Developer with mail address 'dev@company'
	  And I assign myself as a Manager and my mail address is 'manager@company'
	 When Developer changes estimate to 2 hours
	 Then 1 mail is sent to 'manager@company'
	  And Bug should have 1 event of type 'NotifiedManagerAboutChangedEstimateEvent'

Scenario: Change estimate multiple times
	Given I report a new bug 'cannot click on button' without an estimate
	  And I assign a Developer with mail address 'dev@company'
	  And I assign myself as a Manager and my mail address is 'manager@company'
	 When Developer changes estimate to 2 hours
	 When Developer changes estimate to 4 hours
	 When Developer changes estimate to 6 hours
	 Then 3 mails is sent to 'manager@company'
	  And Bug should have 3 event of type 'NotifiedManagerAboutChangedEstimateEvent'

@failure
Scenario: Failure when sending mail
	Given I report a new bug 'cannot click on button' without an estimate
	  And I assign a Developer with mail address 'dev@company'
	  And I assign myself as a Manager and my mail address is '&'
	 When Developer changes estimate to 2 hours
	 Then Bug should have 1 event of type 'FailedToNotifyResourceEvent'

Scenario: Assign developer (simplified)
	Given I report a new bug without an estimate
	When I assign a Developer
	Then Mail is sent to the Developer
	And Bug should have an event log indicating that the mail was sent

@failure
Scenario: Fail when sending mail notification (simplified)
	Given I report a new bug without an estimate
	When I assign a Developer that has an invalid mail address
	Then Bug should have an event log that indicates that mail was not
	And Event should have detailed description of the failure

Scenario: Change estimate (simplified)
	Given I report a new bug without an estimate
	And I assign a Developer
	And I assign myself as a Manager
	When Developer changes estimate
	Then Mail is sent to me
	And Bug should have an event log indicating that mail was sent

Scenario: Change estimate multiple times (simplified)
	Given I report a new bug without an estimate
	  And I assign a Developer
	  And I assign myself as a Manager
	 When Developer changes estimate multiple times
	 Then I as a Manager recieve mail each time estimate is changed
	  And Bug should have an event log for each of the changes that indicates that mail was sent

@failure
Scenario: Failure when sending mail (simplified)
	Given I report a new bug without an estimate
	And I assign a Developer
	And I assign myself as a Manager with an invalid mail address
	When Developer changes estimate
	Then Bug should have an event log that indicates that mail was not
	And Event should have detailed description of the failure

@history
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