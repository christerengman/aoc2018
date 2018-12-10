module Day02

open System.IO

let checksum = 
    // Active pattern matching if there are exactly n identical letters in the input sequence (in this case a string)
    let (|NOfAKind|_|) n input =
        let groups = input |> Seq.countBy id |> Seq.filter (fun (char, count) -> count = n)
        match Seq.length groups with
        | 0 -> None
        | _ -> Some NOfAKind

    // Count IDs with two and three identical letters in parallel using tuples
    File.ReadAllLines(@"02/input.txt")
    |> Seq.map (fun s -> (match s with | NOfAKind 2 -> 1 | _ -> 0), (match s with | NOfAKind 3 -> 1 | _ -> 0))
    |> Seq.reduce (fun (a, b) (x, y) -> (a + x, b + y))
    |> fun (x, y) -> x * y
