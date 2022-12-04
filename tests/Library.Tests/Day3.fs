namespace Library.Tests.Day3

open System.IO
open NUnit.Framework
open Library.Day3
open System.Linq

[<TestFixture>]
type Day3Tests() =
    [<Test>]
    member public _.Part1TestInput() =
        let input = (File.ReadAllText @"Data/Day3/TestInput.txt").Trim()
        Assert.AreEqual(157, Part1.Solve input)

    [<Test>]
    member public _.Part1ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day3/ChallengeInput.txt").Trim()
        Assert.AreEqual(8053, Part1.Solve input)

    [<Test>]
    member public _.Part2TestInput() =
        let input = (File.ReadAllText @"Data/Day3/TestInput.txt").Trim()
        Assert.AreEqual(70, Part2.Solve input)

    [<Test>]
    member public _.Part2ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day3/ChallengeInput.txt").Trim()
        Assert.AreEqual(70, Part2.Solve input)
