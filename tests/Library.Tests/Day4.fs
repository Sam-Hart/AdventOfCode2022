namespace Library.Tests.Day4

open System.IO
open NUnit.Framework
open Library.Day4

[<TestFixture>]
type Day4Tests() =
    [<Test>]
    member public _.Part1TestInput() =
        let input = (File.ReadAllText @"Data/Day4/TestInput.txt").Trim()
        Assert.AreEqual(2, Part1.Solve input)

    [<Test>]
    member public _.Part1ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day4/ChallengeInput.txt").Trim()
        Assert.AreEqual(462, Part1.Solve input)

    [<Test>]
    member public _.Part2TestInput() =
        let input = (File.ReadAllText @"Data/Day4/TestInput.txt").Trim()
        Assert.AreEqual(4, Part2.Solve input)

    [<Test>]
    member public _.Part2ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day4/ChallengeInput.txt").Trim()
        Assert.AreEqual(835, Part2.Solve input)
