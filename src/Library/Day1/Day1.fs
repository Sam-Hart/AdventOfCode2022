namespace Library.Day1

open System

module Calories =
    let FoodListToCaloriesSums (foodList: string) =
        foodList.Split($"{Environment.NewLine}{Environment.NewLine}")
        |> Seq.map (fun elfList -> elfList.Split($"{Environment.NewLine}"))
        |> Seq.map (fun elfList ->
            elfList
            |> Seq.map (fun elfItem ->
                try
                    (Int32.Parse elfItem)
                with :? FormatException ->
                    0)
            |> Seq.sum)

module Part1 =
    let Solve (foodList: string) =
        Calories.FoodListToCaloriesSums foodList |> Seq.max


module Part2 =
    let Solve (foodList: string) =
        Calories.FoodListToCaloriesSums foodList
        |> Seq.sortDescending
        |> Seq.take 3
        |> Seq.sum
