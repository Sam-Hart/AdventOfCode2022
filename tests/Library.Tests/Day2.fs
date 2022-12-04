namespace Library.Tests.Day2

open System.IO
open NUnit.Framework
open Library.Day2
open Library.Day2.RockPaperScissors

[<TestFixture>]
type Day2Tests() =

    [<Test>]
    member public _.ScoreGameRockVsPaper() =
        let game = Game(Weapon.Rock, Weapon.Paper)

        Assert.AreEqual(8, ScoreGame game)

    [<Test>]
    member public _.ScoreGameRockVsScissors() =
        let game = Game(Weapon.Rock, Weapon.Scissors)

        Assert.AreEqual(3, ScoreGame game)

    [<Test>]
    member public _.ScoreGameScissorsVsPaper() =
        let game = Game(Weapon.Scissors, Weapon.Paper)

        Assert.AreEqual(2, ScoreGame game)

    [<Test>]
    member public _.ScoreGameScissorsVsScissors() =
        let game = Game(Weapon.Scissors, Weapon.Scissors)

        Assert.AreEqual(6, ScoreGame game)

    [<Test>]
    member public _.ScoreGameScissorsVsRock() =
        let game = Game(Weapon.Scissors, Weapon.Rock)
        Assert.AreEqual(7, ScoreGame game)

    [<Test>]
    member public _.Part1TestInput() =
        let input = (File.ReadAllText @"Data/Day2/TestInput.txt").Trim()
        Assert.AreEqual(15, Part1.Solve input)

    [<Test>]
    member public _.Part1ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day2/ChallengeInput.txt").Trim()
        Assert.AreEqual(12645, Part1.Solve input)

    [<Test>]
    member public _.ParseGameCorrectlyRockLose() =
        let game = ParseStrategy("A X")
        Assert.AreEqual(game.Self, Weapon.Scissors)


    [<Test>]
    member public _.Part2TestInput() =
        let input = (File.ReadAllText @"Data/Day2/TestInput.txt").Trim()
        Assert.AreEqual(12, Part2.Solve input)

    [<Test>]
    member public _.Part2ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day2/ChallengeInput.txt").Trim()
        Assert.AreEqual(11756, Part2.Solve input)
