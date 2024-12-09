module Day02

open Types
open System

let exampleInput = 
    """
    7 6 4 2 1
    1 2 7 8 9
    9 7 6 2 1
    1 3 2 4 5
    8 6 4 4 1
    1 3 6 7 9"""

let preProcessing (rawInput: string) =
    rawInput.Split("\n", StringSplitOptions.TrimEntries ||| StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun raw -> raw.Split(" ", StringSplitOptions.RemoveEmptyEntries) |> Array.map int)

module Part1 =
    let allDescending xs = xs |> Array.pairwise |> Array.forall (fun (a, b) -> a > b)
    let allAscending xs = xs |> Array.pairwise |> Array.forall (fun (a, b) -> a < b)
    let notTooFast xs = xs |> Array.pairwise |> Array.forall (fun (a, b) -> abs (a - b) <= 3 )
    let notTooSlow xs = xs |> Array.pairwise |> Array.forall (fun (a, b) -> abs (a - b) >= 1 )

    let isSafe (numbers: int array) =
        (notTooFast numbers && notTooSlow numbers) && (allAscending numbers || allDescending numbers)

    let exampleAnswer = 2
    let answer (input: string ) =
        input
        |> preProcessing
        |> Array.where isSafe
        |> Array.length

module Part2 =

    let isSafe (xs: int array) =
        if Part1.isSafe xs then
            true
        else
            // Ridiculously naive implementation!
            [| 0 .. xs.Length - 1 |] 
            |> Array.exists (fun i -> xs |> Array.removeAt i |> Part1.isSafe)

    let exampleAnswer = 4
    let answer (input: string) =
        input
        |> preProcessing
        |> Array.where isSafe
        |> Array.length

open Types
let part1 =
    {
        Day = 2
        Part = 1
        ExampleInput = exampleInput
        Solve = Part1.answer
        ExampleAnswer = Part1.exampleAnswer
        ConfirmedAnswer = Some 236
    }

let part2 = 
    {
        Day = 2
        Part = 2
        ExampleInput = exampleInput
        Solve = Part2.answer
        ExampleAnswer = Part2.exampleAnswer
        ConfirmedAnswer = Some 308
    }
