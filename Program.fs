﻿module Program

open Types

let puzzles = [
    Day01.part1
    Day01.part2
    Day02.part1
    Day02.part2
    Day03.part1
    Day03.part2
]

puzzles |> List.iter Puzzle.run
