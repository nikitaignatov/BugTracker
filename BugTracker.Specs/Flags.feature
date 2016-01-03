Feature: Flags
	In order to utilise the BugTracker to full potential
	As a System
	I should set flags about missing data or other helpful informiation
	As a User
	I should be presented with what actions are missing to be done

Scenario: Project without sprints
	Given A project
	When Number of sprints in the project is 0
	Then Project is flagged with 'no sprints added'

Scenario: Sprint without bugs
	Given A sprint
	When Number of bugs in sprint is 0
	Then Sprint is flagged wit 'no bugs'

Scenario: Bug not in sprint
	Given A bug
	When Bug is not in sprint
	Then Bug is flagged with 'not in sprint'

Scenario: Bug not estimated
	Given A bug
	When Estimate is missing
	Then Bug is flagged with 'not estimated'

Scenario: Bug has no resources assigned
	Given A bug
	When Rources are not assigned
	Then Bug is flagged with 'no resources assigned'