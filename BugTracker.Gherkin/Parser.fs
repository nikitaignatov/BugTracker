namespace BugTracker.Gherkin

open Model

module Parser =
    open FParsec

    let ws = spaces
    let str s = pstring s
    let token : Parser<string, unit> = many1Satisfy (fun c -> isDigit c || isLetter c)
    let input : Parser<string, unit> = ws >>. many1Chars (noneOf "\n") .>> optional (many (pchar '\n'))
    let cellInput : Parser<string, unit> = many1Satisfy (isNoneOf "|\n")

    /// Comment parser
    let comment = str "#" >>. input |>> Comment

    /// Tag parser
    let tags = str "@" >>. token |>> Tag |> many

    /// Table parser
    let table = pchar '|' >>. many (opt cellInput .>> str "|") .>> optional (pchar '\n') |>> TableRow
                |> many
                |>> Table

    /// Definition parser TODO:refactor
    let definition identity s =
        (str identity >>. input .>>. opt table) .>>. many (str "And " >>. input .>>. opt table)
        |>> (fun (a, b) -> (a :: b) |> List.map (Definition >> s))

    /// Steps parser
    let steps = definition "Given " Given <|> definition "When " When <|> definition "Then " Then |> many

    /// Examples parser
    let examples = str "Examples:" >>. table |>> Examples |> many

    /// Background parser
    let background =
        str "Background:" >>. steps |>> (fun c ->
        c
        |> List.collect id
        |> Background)

    /// Scenario outlines parser
    let scenarioOutlines =
        str "Scenario Outline:" >>. input .>>. steps .>>. examples
        |>> (fun ((a, b), c) -> ScenarioOutline(a, (b |> List.collect id), c))

    /// Scenario parser
    let scenarios =
        str "Scenario:" >>. input .>>. steps |>> (fun (a, c) ->
        c
        |> List.collect id
        |> (fun m -> Scenario(a, m)))

    /// Scenario
    let blocks = scenarioOutlines <|> scenarios |> many

    /// Feature
    let feature = (str "Feature:" >>. input .>>. opt background .>>. blocks) |>> (fun ((a, b), c) -> Feature(a, b, c))
