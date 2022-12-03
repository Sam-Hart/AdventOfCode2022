namespace Library.Tests.Day1

open System.IO
open NUnit.Framework
open Library.Day1

[<TestFixture>]
type Day1Tests() =

    [<Test>]
    member public _.Part1TestInput() =
        let input = (File.ReadAllText @"Data/Day1/TestInput.txt").Trim()
        Assert.AreEqual(24000, Part1.Solve input)

    [<Test>]
    member public _.Part2TestInput() =
        let input = (File.ReadAllText @"Data/Day1/TestInput.txt").Trim()
        Assert.AreEqual(45000, Part2.Solve input)

    [<Test>]
    member public _.Part1ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day1/ChallengeInput.txt").Trim()
        Assert.AreEqual(69883, Part1.Solve(input))

    [<Test>]
    member public _.Part2ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day1/ChallengeInput.txt").Trim()
        Assert.AreEqual(207576, Part2.Solve input)
