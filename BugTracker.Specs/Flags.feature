Feature: Flags
	In order to utilise the BugTracker to full potential
	As a System
	I should set flags about missing data or other helpful informiation
	As a User
	I should be presented with what actions are missing to be done

Scenario: Project without sprints
	Given I have a project
	When Number of sprints in the project is 0
	Then Project is flagged with 'missing sprints'

Scenario: Sprint without bugs
	Given I have a sprint
	When Number of bugs in sprint is 0
	Then Sprint is flagged wit 'missing bugs'

Scenario: Bug not in sprint
	Given I have a bug
	When Bug is not in sprint
	Then Bug is flagged with 'not in sprint'

Scenario: Bug not estimated

Scenario: Bug missing resources