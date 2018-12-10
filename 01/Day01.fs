module Day01

open System.IO
open System

let resultingFrequency =
    File.ReadAllLines("01/input.txt")
    |> Seq.sumBy (fun s -> s |> int)

let firstFrequenceReachedTwice =
    let deltas =
        File.ReadAllLines("01/input.txt")
        |> Array.map (fun s -> s |> int)
    let ds = deltas.Length

    let rec twice history lastf di =
        let delta = Array.get deltas di
        let f = lastf + delta
        // printfn "hs: %d, di: %d, d: %d, f: %d" (Set.count history) di delta f
        if (Set.contains f history) then
             f
        else
            twice (history.Add f) f ((di + 1) % ds)

    twice Set.empty 0 0
