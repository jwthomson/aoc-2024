
type Puzzle = {
    Day: int
    Part: int
    ExampleInput: string
    ExampleAnswer: int
    Solve: string -> int
    ConfirmedAnswer: int option
}

module Puzzle =
    let run (puzzle: Puzzle) =
        let info = $"%02i{puzzle.Day}-P%i{puzzle.Part}"
        match puzzle.ConfirmedAnswer with
        | Some a ->
            printfn $"%s{info}: %i{a} (confirmed correct, not recalculated)"
        | None ->
            let inputFile = $"Day%02i{puzzle.Day}Input.txt"
            let input = System.IO.File.ReadAllText inputFile
            match puzzle.Solve puzzle.ExampleInput with
            | x when x = puzzle.ExampleAnswer -> printfn $"%s{info}: %i{puzzle.Solve input}"
            | x -> printfn $"%s{info}: Wrong example answer, expected %i{puzzle.ExampleAnswer} but got %i{x}"
