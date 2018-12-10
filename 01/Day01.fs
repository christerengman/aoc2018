module Day01

open System.IO

let resultingFrequency =
    File.ReadAllLines("01/input.txt")
    |> Seq.sumBy (fun s -> s |> int)

let firstFrequenceReachedTwice =
    let deltas =
        File.ReadAllLines("01/input.txt")
        |> Array.map (fun s -> s |> int)
    let dl = deltas.Length

    let rec twice history prevf di =
        let delta = Array.get deltas di
        let f = prevf + delta
        if (Set.contains f history) then
             f
        else
            twice (history.Add f) f ((di + 1) % dl)

    twice Set.empty 0 0
