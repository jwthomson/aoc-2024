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
    let solver _ = 0

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
        ExampleAnswer = -99
        ConfirmedAnswer = None
}
