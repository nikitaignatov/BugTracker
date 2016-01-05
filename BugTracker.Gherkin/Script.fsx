#r @"..\packages\FParsec.1.0.2\lib\portable-net45+netcore45+wpa81+wp8\FParsecCS.dll"
#r @"..\packages\FParsec.1.0.2\lib\portable-net45+netcore45+wpa81+wp8\FParsec.dll"

#load "Model.fs"
#load "Parser.fs"

open FParsec
open BugTracker.Gherkin
open Parser

let test p str =
    match run p str with
    | Success(result, _, _) -> printfn "Success: %A" result
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg


test comment "#sdjkh ksdkjs d"
test table "|m5|
| d|"
test feature "Feature:lakdjal dkjakljd alkjd aldjk"
test feature "Feature: testing
Scenario: loop
Given I have some money
When I ran out of money
Then I make a loan in the bank
And wtf
Scenario: loop2
Given I have some money
When I ran out of money
Then I make a loan in the bank
And  options
But  som stuff
|loan amount|duration|
|5000|25|
|3000|12|
|3000| |
|| |
"
test tags "@s"
test tags "@a2 @sdsd"
