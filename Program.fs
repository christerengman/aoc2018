module Program

open System

[<EntryPoint>]
let main argv =
    printfn "Advent of Code 2018"

    printfn "1a: %d" Day01.resultingFrequency
    printfn "1b: %d" Day01.firstFrequenceReachedTwice
    printfn "2a: %d" Day02.checksum

    0 // return an integer exit code
