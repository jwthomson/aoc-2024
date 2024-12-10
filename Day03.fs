module Day03

open Types
open System.Text.RegularExpressions

module Part1 =
    let getMuls s =
        s
        |> Regex("""mul\((\d+),(\d+)\)""").Matches
        |> Seq.toArray
        |> Array.map (fun m -> int m.Groups[1].Value, int m.Groups[2].Value)

    let solver input =
        input
        |> getMuls
        |> Array.sumBy (fun (x,y) -> x * y)

module Part2 =
    let getMulsWithIndex s =
        s
        |> Regex("""mul\((\d+),(\d+)\)""").Matches
        |> Seq.toArray
        |> Array.map (fun m -> int m.Groups[1].Value, int m.Groups[2].Value, m.Groups[0].Index)

    let getDoIndexes s =
        s
        |> Regex("""do\(\)""").Matches
        |> Seq.toArray
        |> Array.map (fun m -> m.Captures.Item(0).Index)

    let getDontIndexes s =
        s
        |> Regex("""don't\(\)""").Matches
        |> Seq.toArray
        |> Array.map (fun m -> m.Captures.Item(0).Index)

    let solver input =
        
        let shouldInclude  (dos: int array) (donts: int array) (index: int) =
            let lastDo =
                dos
                |> Array.tryFindBack (fun x -> x < index)
                |> Option.defaultValue 0
            
            let lastDont =
                donts
                |> Array.tryFindBack (fun x -> x < index)
                |> Option.defaultValue -1

            lastDont < lastDo

        // Sort is redundant, but just in case
        let dos = input |> getDoIndexes |> Array.sort
        let donts = input |> getDontIndexes |> Array.sort

        input
        |> getMulsWithIndex
        |> Array.choose (fun (a, b, i) -> if shouldInclude dos donts i then Some (a * b) else None)
        |> Array.sum

        (*
             x   ✔
        1    -   0 = Some 1
        28  20   0 = None
        48  20   0 = None
        64  20  59 = Some 64
        
        *)


let part1 = {
    Day = 3
    Part = 1
    Solver = Part1.solver
    ExampleInput = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
    ExampleAnswer = 161
    ConfirmedAnswer = Some 153469856
}

let part2 = {
    part1 with
        Part = 2
        Solver = Part2.solver
        ExampleInput = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"
        ExampleAnswer = 48
        ConfirmedAnswer = None
}
