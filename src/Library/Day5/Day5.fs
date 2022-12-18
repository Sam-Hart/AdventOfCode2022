namespace Library.Day5

open System
open System.Text.RegularExpressions

module CrateMover =
    let private take =
        fun amount ->
            fun (source: option<list<'a>>) ->
                match source with
                | Some(s) -> Some(s[0 .. (s.Length - amount - 1)])
                | None -> Some(List.empty)

    let private add =
        fun toAdd ->
            fun (destination: option<list<'a>>) ->
                match destination with
                | Some(d) -> Some(List.concat [ d; toAdd ])
                | None -> Some(List.empty)

    let ParseStacks (stackDetails: string) =
        stackDetails.Split(Environment.NewLine)
        |> Seq.rev
        |> (fun stackContentsRev ->
            let stacks =
                Regex("\d+").Matches(stackContentsRev |> Seq.head)
                |> Seq.map (fun m ->
                    stackContentsRev
                    |> Seq.skip 1
                    |> Seq.filter (fun r -> r[m.Index] <> ' ')
                    |> Seq.map (fun r ->
                        let itemEnd = r[ m.Index .. ].IndexOf(']') + m.Index - 1
                        r[m.Index .. itemEnd])
                    |> (fun stack -> m.Value, stack |> Seq.toList))
                |> Map

            stacks)

    let Label (stacks: Map<string, list<string>>) =
        stacks |> Seq.map (fun x -> x.Value |> Seq.last) |> String.concat ""

    type CraneOperation =
        | Single of Map<string, list<string>> * string
        | Multi of Map<string, list<string>> * string

    let MoveCrates (operation: CraneOperation) =
        let instructionRx = Regex(@"move (\d+) from (\d+) to (\d+)", RegexOptions.Compiled)

        let (stacks, instructions, postOp) =
            match operation with
            | Single(s, i) -> (s, i, List.rev)
            | Multi(s, i) -> (s, i, (fun x -> x))

        let mutable rearrangedStacks = stacks

        instructions.Split(Environment.NewLine)
        |> Seq.iter (fun instruction ->
            let m = (instructionRx.Match instruction)

            let (amount, source, destination) =
                (Int32.Parse m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value)

            let sourceSize = rearrangedStacks[source] |> Seq.length

            let toMove = rearrangedStacks[source][(sourceSize - amount) .. sourceSize] |> postOp

            rearrangedStacks <- Map.change source (take amount) rearrangedStacks
            rearrangedStacks <- Map.change destination (add toMove) rearrangedStacks
            ())

        rearrangedStacks

module Part1 =

    let Solve (program: string) =
        let programParts = program.Split($"{Environment.NewLine}{Environment.NewLine}")
        let instructions = programParts[1]
        let stackDetails = programParts[0]
        let stacks = CrateMover.ParseStacks stackDetails

        let movedStacks =
            CrateMover.MoveCrates(CrateMover.CraneOperation.Single(stacks, instructions))

        movedStacks |> CrateMover.Label


module Part2 =
    let Solve (program: string) =
        let programParts = program.Split($"{Environment.NewLine}{Environment.NewLine}")
        let instructions = programParts[1]
        let stackDetails = programParts[0]
        let stacks = CrateMover.ParseStacks stackDetails

        let movedStacks =
            CrateMover.MoveCrates(CrateMover.CraneOperation.Multi(stacks, instructions))


        movedStacks |> CrateMover.Label
