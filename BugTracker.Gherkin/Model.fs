namespace BugTracker.Gherkin

module Model =
    type Tag =
        | Tag of string

    type TableRow =
        | TableRow of string option list

    type Table =
        | Table of TableRow list

    type Comment =
        | Comment of string

    type Definition =
        | Definition of string * Table option

    type Step =
        | Given of Definition
        | When of Definition
        | Then of Definition

    type Background =
        | Background of Step list

    type Examples =
        | Examples of Table

    type Scenario =
        | Scenario of string * Step list
        | ScenarioOutline of string * Step list * Examples list

    type Feature =
        | Feature of string * Background option * Scenario list
