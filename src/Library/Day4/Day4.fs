namespace Library.Day4

open System
open System.Linq

module Parsing =
    let ParseRange (r: string) =
        r.Split("-")
        |> Seq.map Int32.Parse
        |> fun pair -> pair.ToList() |> (fun pair -> (pair[0], pair[1]))

    let ParsePairOfRanges (pair: string) =
        pair.Split(",")
        |> Seq.map ParseRange
        |> (fun ranges -> (ranges.First(), ranges.Last()))

module Part1 =
    let Solve (ranges: string) =
        (ranges.Split(Environment.NewLine)
         |> Seq.map Parsing.ParsePairOfRanges
         |> Seq.filter (fun pair ->
             (fst (fst pair) >= fst (snd pair) && snd (fst pair) <= snd (snd pair))
             || (fst (fst pair) <= fst (snd pair) && snd (fst pair) >= snd (snd pair))))
            .Count()

module Part2 =
    let Solve (ranges: string) =
        (ranges.Split(Environment.NewLine)
         |> Seq.map Parsing.ParsePairOfRanges
         |> Seq.filter (fun pair ->
             let firstStart = fst (fst pair)
             let firstEnd = snd (fst pair)
             let secondStart = fst (snd pair)
             let secondEnd = snd (snd pair)

             (firstStart <= secondEnd && secondStart <= firstStart)
             || (secondStart <= firstEnd && firstStart <= secondStart)))
            .Count()
