namespace Library.Day6

module DataParser =
    let Finder (data: string, marker: int) =
        marker
        + (data[0 .. data.Length - marker]
           |> Seq.mapi (fun i _ -> data[i .. i + marker - 1] |> Set)
           |> Seq.findIndex (fun c -> c.Count = marker))

module Part1 =
    let Solve (data: string) = DataParser.Finder(data, 4)

module Part2 =
    let Solve (data: string) = DataParser.Finder(data, 14)
