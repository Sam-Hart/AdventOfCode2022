namespace Library.Day2

open System
open MathNet.Numerics

module RockPaperScissors =
    type Weapon =
        | Rock = 0
        | Paper = 1
        | Scissors = 2

    let codeToWeapon (weaponCode: string) =
        match weaponCode with
        | "A"
        | "X" -> Weapon.Rock
        | "B"
        | "Y" -> Weapon.Paper
        | "C"
        | "Z" -> Weapon.Scissors
        | _ -> raise <| new ArgumentException($"Weapon code {weaponCode} not found")

    type Game(opponent: Weapon, self: Weapon) =
        member _.Opponent = opponent
        member _.Self = self

    let ParseGuideIncorrectly (guide: string) =
        guide.Trim().Split(Environment.NewLine)
        |> Seq.map (fun game -> game.Split(" "))
        |> Seq.map (fun pair -> Game(codeToWeapon pair[0], codeToWeapon pair[1]))

    let ParseStrategy (strategy: string) =
        strategy.Split(" ")
        |> fun pair -> (codeToWeapon pair[0], pair[1])
        |> fun pair ->
            match pair with
            | (weapon, result) when result = "X" ->
                // Warning: F#'s % operator is a REMAINDER operator
                // not a MODULUS operator
                // Also - LanguagePrimitives.EnumOfValue will return a number
                // when the value provided isn't in the Enum
                Game(
                    weapon,
                    LanguagePrimitives.EnumOfValue(Euclid.Modulus(LanguagePrimitives.EnumToValue weapon - 1, 3))
                )
            | (weapon, result) when result = "Y" -> Game(weapon, weapon)
            | (weapon, result) when result = "Z" ->
                Game(
                    weapon,
                    LanguagePrimitives.EnumOfValue(Euclid.Modulus(LanguagePrimitives.EnumToValue weapon + 1, 3))
                )
            | _ -> raise <| new ArgumentException($"Invalid result code {snd pair}")

    let ParseGuideCorrectly (guide: string) =
        guide.Trim().Split(Environment.NewLine) |> Seq.map (ParseStrategy)

    let ScoreGame (game: Game) =
        (match (game.Opponent, game.Self) with
         | (opp, self) when opp = self -> 3
         | (opp, self) when
             (opp = Weapon.Rock && self = Weapon.Scissors)
             || (LanguagePrimitives.EnumToValue opp - LanguagePrimitives.EnumToValue self = 1)
             ->
             0
         | _ -> 6)
        + ((LanguagePrimitives.EnumToValue game.Self) + 1)

    let ScoreGuide (guide: seq<Game>) = guide |> Seq.map ScoreGame

module Part1 =
    let Solve (guide: string) =
        RockPaperScissors.ParseGuideIncorrectly guide
        |> RockPaperScissors.ScoreGuide
        |> Seq.sum

module Part2 =
    let Solve (guide: string) =
        RockPaperScissors.ParseGuideCorrectly guide
        |> RockPaperScissors.ScoreGuide
        |> Seq.sum
