namespace Library.Day3

open System
open System.Collections.Generic
open System.Linq

module Part1 =
    let RucksackPriority (rucksack: string) =
        let left = rucksack[ .. (rucksack.Length / 2) - 1 ].ToHashSet()
        let right = rucksack[ rucksack.Length / 2 .. ].ToHashSet()
        let duplicated = left.Intersect(right).First()
        let priority = int duplicated - int 'a' + 1
        if priority < 0 then priority + 58 else priority

    let Solve (rucksacks: string) =
        rucksacks.Split(Environment.NewLine) |> Seq.map RucksackPriority |> Seq.sum

module Part2 =
    type Troop(first: string, second: string, third: string) =
        member _.First = first.ToHashSet()
        member _.Second = second.ToHashSet()
        member _.Third = third.ToHashSet()

    let Solve (rucksacks: string) =
        rucksacks.Split(Environment.NewLine).Chunk(3)
        |> Seq.map (fun chunk -> Troop(chunk[0], chunk[1], chunk[2]))
        |> Seq.map (fun troop ->
            int (troop.First.Intersect(troop.Second.Intersect(troop.Third)).First())
            - int 'a'
            + 1)
        |> Seq.map (fun c -> if c < 0 then c + 58 else c)
        |> Seq.sum
