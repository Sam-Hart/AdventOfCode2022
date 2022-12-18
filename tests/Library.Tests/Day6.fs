namespace Library.Tests.Day6

open System
open System.IO
open Library.Day6
open NUnit.Framework
open System.Text.RegularExpressions

[<TestFixture>]
type Day6Tests() =
    [<Test>]
    member public _.Part1TestInput() =
        let input = ((File.ReadAllText @"Data/Day6/TestInput.txt"))
        let testRx = Regex(@"([a-z]+)\n(\d+)")

        testRx.Matches input
        |> Seq.iter (fun test ->
            let (data, start) = (test.Groups[1].Value, Int32.Parse test.Groups[2].Value)
            Assert.AreEqual(start, Part1.Solve data)
            ())

    [<Test>]
    member public _.Part1ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day6/ChallengeInput.txt").Trim()
        Assert.AreEqual(1542, Part1.Solve input)

    [<Test>]
    member public _.Part2TestInput() =
        let input = ((File.ReadAllText @"Data/Day6/TestInput2.txt"))
        let testRx = Regex(@"([a-z]+)\n(\d+)")

        testRx.Matches input
        |> Seq.iter (fun test ->
            let (data, start) = (test.Groups[1].Value, Int32.Parse test.Groups[2].Value)
            Assert.AreEqual(start, Part2.Solve data)
            ())

    [<Test>]
    member public _.Part2ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day6/ChallengeInput.txt").Trim()
        Assert.AreEqual(3153, Part2.Solve input)
