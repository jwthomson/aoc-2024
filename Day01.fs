module Day01

open Types
open System

let preProcessing (rawInput: string) =
    rawInput.Split("\n", StringSplitOptions.TrimEntries ||| StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun rawPair -> rawPair.Split(" ", StringSplitOptions.RemoveEmptyEntries) |> Array.map int)

module Part1 =
    let solver (input: string ) =
        input
        |> preProcessing
        |> Array.transpose
        |> Array.map Array.sort
        |> Array.transpose
        |> Array.sumBy (fun pair ->
            pair
            |> Array.reduce (-)
            |> abs)

module Part2 =
    let solver (input: string) =
        
        let lr = 
            input
            |> preProcessing
            |> Array.transpose
        
        let ls = lr.[0]
        let rs = lr.[1]
        
        let counts =
            rs
            |> Array.groupBy id
            |> Array.map (fun (k, ks) -> k, ks.Length)
            |> Map
        
        ls |> Array.sumBy (fun x ->
            if counts |> Map.containsKey x then x * counts[x] else 0)

open Types
let part1 = {
    Day = 1
    Part = 1
    Solver = Part1.solver
    ExampleInput = "\
3   4
4   3
2   5
1   3
3   9
3   3"
    ExampleAnswer = 11
    ConfirmedAnswer = Some 2756096
}

let part2 = {
    part1 with
        Part = 2
        Solver = Part2.solver
        ExampleAnswer = 31
        ConfirmedAnswer = Some 23117829
}
