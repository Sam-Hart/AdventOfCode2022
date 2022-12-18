namespace Library.Tests.Day5

open System.IO
open System.Text.RegularExpressions
open System.Collections.Generic
open NUnit.Framework
open Library.Day5

[<TestFixture>]
type Day5Tests() =
    [<Test>]
    member public _.Part1TestInput() =
        let input = (File.ReadAllText @"Data/Day5/TestInput.txt").TrimEnd()
        Assert.AreEqual("CMZ", Part1.Solve input)

    [<Test>]
    member public _.Part1ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day5/ChallengeInput.txt").TrimEnd()
        Assert.AreEqual("BWNCQRMDB", Part1.Solve input)

    [<Test>]
    member public _.Part2TestInput() =
        let input = (File.ReadAllText @"Data/Day5/TestInput.txt").TrimEnd()
        Assert.AreEqual("MCD", Part2.Solve input)

    [<Test>]
    member public _.Part2ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day5/ChallengeInput.txt").TrimEnd()
        Assert.AreEqual("NHWZCBNBF", Part2.Solve input)
