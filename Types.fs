module Types

type Puzzle = {
    Day: int
    Part: int
    ExampleInput: string
    ExampleAnswer: int
    Solver: string -> int
    ConfirmedAnswer: int option
}

module Puzzle =

    let shortString (puzzle: Puzzle) = $"%02i{puzzle.Day}-P%i{puzzle.Part}"

    let solved (puzzle: Puzzle) = puzzle.ConfirmedAnswer |> Option.isSome

    let run (puzzle: Puzzle) =
        let desc = shortString puzzle
        match puzzle.ConfirmedAnswer with
        | Some a ->
            printfn $"%s{desc}: %i{a} ✔"
        | None ->
            match puzzle.Solver puzzle.ExampleInput with
            | x when x = puzzle.ExampleAnswer ->
                let inputFile = $"Day%02i{puzzle.Day}Input.txt"
                let input = System.IO.File.ReadAllText inputFile
                printfn $"%s{desc}: %i{puzzle.Solver input}"
            | x -> printfn $"%s{desc}: Wrong example answer, expected %i{puzzle.ExampleAnswer} but got %i{x}"
